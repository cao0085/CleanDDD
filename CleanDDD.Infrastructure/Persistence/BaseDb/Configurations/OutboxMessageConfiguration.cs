using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanDDD.Infrastructure.Persistence.BaseDb.Models;

namespace CleanDDD.Infrastructure.Persistence.BaseDb.Configurations
{
    public class OutboxMessageConfiguration : IEntityTypeConfiguration<OutboxMessages>
    {
        public void Configure(EntityTypeBuilder<OutboxMessages> builder)
        {
            builder.ToTable("OutboxMessages");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.EventType)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.PayloadJson)
                .IsRequired();

            builder.Property(x => x.Status)
                .HasMaxLength(50)
                .IsRequired()
                .HasDefaultValue("Pending");

            builder.Property(x => x.RetryCount)
                .HasDefaultValue(0);

            builder.Property(x => x.MaxRetry)
                        .IsRequired()
                        .HasDefaultValue(3);

            builder.Property(x => x.NextAttemptAt)
                .IsRequired()
                .HasDefaultValueSql("SYSUTCDATETIME()");

            builder.Property(x => x.CreatedAt)
                .HasDefaultValueSql("SYSUTCDATETIME()");

            builder.Property(x => x.LastError)
                .HasColumnType("nvarchar(max)");

            builder.Property(x => x.ProcessedAt)
                .IsRequired(false);
        }
    }
}
