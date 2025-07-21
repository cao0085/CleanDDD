using CleanDDD.Domain;
using CleanDDD.Infrastructure.Persistence.BaseDb.Models;
using CleanDDD.Infrastructure.Persistence.BaseDb;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace CleanDDD.Infrastructure.Persistence.Repository
{
    public class OutboxRepository : IOutboxRepository
    {
        private readonly BaseDbContext _db;
        public OutboxRepository(BaseDbContext db) => _db = db;

        public Task AddAsync(INotification @event)
        {
            var msg = new OutboxMessages
            {
                Id = Guid.NewGuid(),
                EventType = @event.GetType().Name,
                PayloadJson = JsonSerializer.Serialize(@event)
            };
            return _db.AddAsync(msg).AsTask();
        }
    }
}
