using System;

namespace CleanDDD.Infrastructure.Persistence.BaseDb.Models
{
    public class OutboxMessage
    {
        public Guid Id { get; set; }

        public string EventType { get; set; } = null!;
        public string PayloadJson { get; set; } = null!;

        public string Status { get; set; } = "Pending";
        public int RetryCount { get; set; } = 0;
        public string? LastError { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ProcessedAt { get; set; }
    }
}
