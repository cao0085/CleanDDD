using System;

namespace CleanDDD.Infrastructure.Persistence.BaseDb.Models
{
    public class OutboxMessages
    {
        public Guid Id { get; set; }

        public string EventType { get; set; } = null!;
        public string PayloadJson { get; set; } = null!;

        public string Status { get; set; } = "Pending";
        public int RetryCount { get; set; } = 0;
        public int MaxRetry { get; set; }
        public string? LastError { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ProcessedAt { get; set; }
        public DateTime? NextAttemptAt { get; set; }
    }
}
