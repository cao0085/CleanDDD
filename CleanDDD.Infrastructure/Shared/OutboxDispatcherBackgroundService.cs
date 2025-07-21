using System.Text.Json;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using CleanDDD.Infrastructure.Persistence.BaseDb;
using CleanDDD.Infrastructure.Persistence.BaseDb.Models;

public class OutboxDispatcherBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<OutboxDispatcherBackgroundService> _logger;

    public OutboxDispatcherBackgroundService(IServiceProvider serviceProvider, ILogger<OutboxDispatcherBackgroundService> logger)
    {
        _serviceProvider = serviceProvider;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("✅ Outbox dispatcher started.");

        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<BaseDbContext>();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            //var messages = await db.OutboxMessages
            //    .Where(m => m.Status == "Pending")
            //    .OrderBy(m => m.CreatedAt)
            //    .Take(10)
            //    .ToListAsync(stoppingToken);
            var messages = await db.OutboxMessages
                .Where(m =>
                    m.Status == "Pending" &&
                    m.RetryCount < m.MaxRetry)
                .Take(10)
                .ToListAsync(stoppingToken);


            foreach (var msg in messages)
            {
                try
                {
                    var type = Type.GetType($"CleanDDD.Domain.Users.Events.{msg.EventType}, CleanDDD.Domain"); // 調整你的 namespace
                    if (type is null)
                    {
                        msg.Status = "Failed";
                        msg.LastError = "❌ Cannot resolve event type.";
                        continue;
                    }

                    var evt = (INotification?)JsonSerializer.Deserialize(msg.PayloadJson, type);
                    if (evt is null)
                    {
                        msg.Status = "Failed";
                        msg.LastError = "❌ Cannot deserialize event.";
                        continue;
                    }

                    await mediator.Publish(evt, stoppingToken);

                    msg.Status = "Sent";
                    msg.ProcessedAt = DateTime.UtcNow;
                }
                catch (Exception ex)
                {
                    msg.RetryCount++;
                    msg.LastError = ex.Message;

                    if (msg.RetryCount >= 3)
                    {
                        msg.Status = "DeadLetter";
                        _logger.LogWarning($"⚠️ Outbox event {msg.Id} marked as DeadLetter after 3 retries.");
                    }
                    else
                    {
                        msg.NextAttemptAt = DateTime.UtcNow + GetRetryDelay(msg.RetryCount);
                        _logger.LogError(ex, $"❌ Failed to process outbox event {msg.Id} (RetryCount: {msg.RetryCount})");
                    }
                }
            }

            await db.SaveChangesAsync(stoppingToken);

            await Task.Delay(TimeSpan.FromSeconds(5), stoppingToken);
        }
    }

    private static TimeSpan GetRetryDelay(int retryCount)
    {
        // 1min → 2min → 4min → 最多 15min
        var delayMinutes = Math.Min(Math.Pow(2, retryCount), 15);
        return TimeSpan.FromMinutes(delayMinutes);
    }
}
