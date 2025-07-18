using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanDDD.Infrastructure.Persistence.CompanyDb.Models;

namespace CleanDDD.Infrastructure.Persistence.CompanyDb.Configurations;

public partial class RoadSideOrderDetailConfiguration : IEntityTypeConfiguration<RoadSideOrderDetail>
{
    public void Configure(EntityTypeBuilder<RoadSideOrderDetail> entity)
    {
        entity.HasKey(e => new { e.RoadSideOrderDetailId, e.RoadSideOrderId }).HasName("PK_RoadSideOrderDetail_1");

        entity.Property(e => e.RoadSideOrderDetailId).HasComment("ID");
        entity.Property(e => e.RoadSideOrderId).HasComment("繳費單ID");
        entity.Property(e => e.Amount)
            .HasComment("區間金額")
            .HasColumnType("decimal(18, 0)");
        entity.Property(e => e.CumulativeAmount)
            .HasComment("累計金額")
            .HasColumnType("decimal(18, 0)");
        entity.Property(e => e.CumulativeTime).HasComment("累計時數(分)");
        entity.Property(e => e.InsertTime)
            .HasComment("建立時間")
            .HasColumnType("datetime");
        entity.Property(e => e.InsertUserInfoId).HasComment("開單人員ID");
        entity.Property(e => e.ParkingTimeEnd)
            .HasMaxLength(10)
            .HasComment("結束計費區間\r\nHH:mm");
        entity.Property(e => e.ParkingTimeStart)
            .HasMaxLength(10)
            .HasComment("起始計費區間\r\nHH:mm");
        entity.Property(e => e.State).HasComment("狀態\r\n1:正常\r\n3:作廢\r\n9:刪除");

        entity.HasOne(d => d.RoadSideOrder).WithMany(p => p.RoadSideOrderDetail)
            .HasForeignKey(d => d.RoadSideOrderId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_RoadSideOrderDetail_RoadSideOrder");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<RoadSideOrderDetail> modelBuilder);
}
