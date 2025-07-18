using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanDDD.Infrastructure.Persistence.CompanyDb.Models;

namespace CleanDDD.Infrastructure.Persistence.CompanyDb.Configurations;

public partial class RateDetailConfiguration : IEntityTypeConfiguration<RateDetail>
{
    public void Configure(EntityTypeBuilder<RateDetail> entity)
    {
        entity.Property(e => e.RateDetailId).HasComment("ID");
        entity.Property(e => e.CycleHour).HasComment("循環時數(小時)");
        entity.Property(e => e.DateType).HasComment("日期類型\r\n1: 平日\r\n2: 假日\r\n3: 特殊日");
        entity.Property(e => e.DayChangeTime)
            .HasMaxLength(10)
            .HasComment("患日時間 (HH:mm)");
        entity.Property(e => e.LimitAmount)
            .HasComment("上限金額")
            .HasColumnType("decimal(18, 0)");
        entity.Property(e => e.ParkBuffer).HasComment("入場緩衝時間(分)");
        entity.Property(e => e.PayBuffer).HasComment("繳費緩衝時間(分)");
        entity.Property(e => e.RateInfoId).HasComment("費率ID");
        entity.Property(e => e.SpecialOffer).HasComment("優惠設定\r\n {\r\n    Time: int (分),\r\n    Count: int,\r\n    OffPercent: int (0-100)\r\n   }");
        entity.Property(e => e.State).HasComment("狀態\r\n0: 無效\r\n1: 有效\r\n9: 刪除");
        entity.Property(e => e.TimePeriod).HasComment("時段設定\r\n[object]\r\nBilings: [\r\n    {\r\n    Amount: int,\r\n    ChargeAmount: int,\r\n    Frequency: int (分鐘),\r\n    Count : int (次數) \r\n    }\r\n]");

        entity.HasOne(d => d.RateInfo).WithMany(p => p.RateDetail)
            .HasForeignKey(d => d.RateInfoId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_RateDetail_RateInfo");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<RateDetail> modelBuilder);
}
