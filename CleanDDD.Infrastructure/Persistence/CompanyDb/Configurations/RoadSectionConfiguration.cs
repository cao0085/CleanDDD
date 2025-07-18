using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanDDD.Infrastructure.Persistence.CompanyDb.Models;

namespace CleanDDD.Infrastructure.Persistence.CompanyDb.Configurations;

public partial class RoadSectionConfiguration : IEntityTypeConfiguration<RoadSection>
{
    public void Configure(EntityTypeBuilder<RoadSection> entity)
    {
        entity.Property(e => e.CommonGrid)
            .HasMaxLength(100)
            .HasComment("一般車格");
        entity.Property(e => e.CommonRateId).HasComment("平日一般費率");
        entity.Property(e => e.DisabilityGrid)
            .HasMaxLength(100)
            .HasComment("身障車格");
        entity.Property(e => e.DisabilityRateId).HasComment("平日身障費率");
        entity.Property(e => e.ExtCode)
            .HasMaxLength(50)
            .HasComment("外部編碼");
        entity.Property(e => e.HolidayEndTime)
            .HasMaxLength(10)
            .HasComment("假日營業結束時間");
        entity.Property(e => e.HolidayStartTime)
            .HasMaxLength(10)
            .HasComment("假日營業開始時間");
        entity.Property(e => e.LocalCityArea)
            .HasMaxLength(50)
            .HasComment("行政區(場別)");
        entity.Property(e => e.Name)
            .HasMaxLength(50)
            .HasComment("路段名稱");
        entity.Property(e => e.SiteInfoId).HasComment("場地ID");
        entity.Property(e => e.UnloadGrid)
            .HasMaxLength(100)
            .HasComment("卸貨車格");
        entity.Property(e => e.UnloadRateId).HasComment("平日卸貨費率");
        entity.Property(e => e.WeekdayEndTime)
            .HasMaxLength(10)
            .HasComment("平日結束時間");
        entity.Property(e => e.WeekdayStartTime)
            .HasMaxLength(10)
            .HasComment("平日營業時間");

        entity.HasOne(d => d.SiteInfo).WithMany(p => p.RoadSection)
            .HasForeignKey(d => d.SiteInfoId)
            .OnDelete(DeleteBehavior.ClientSetNull)
            .HasConstraintName("FK_RoadSection_Site");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<RoadSection> modelBuilder);
}
