using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanDDD.Infrastructure.Persistence.CompanyDb.Models;

namespace CleanDDD.Infrastructure.Persistence.CompanyDb.Configurations;

public partial class RateInfoConfiguration : IEntityTypeConfiguration<RateInfo>
{
    public void Configure(EntityTypeBuilder<RateInfo> entity)
    {
        entity.Property(e => e.RateInfoId).HasComment("ID");
        entity.Property(e => e.EffectiveDay)
            .HasComment("生效日")
            .HasColumnType("datetime");
        entity.Property(e => e.Name)
            .HasMaxLength(100)
            .HasComment("費率名稱");
        entity.Property(e => e.RateIdentity).HasComment("身分別\r\n1: 一般\r\n2: 身障\r\n3: 電動\r\n4: 卸貨");
        entity.Property(e => e.State).HasComment("狀態\r\n0: 無效\r\n1: 有效\r\n9: 刪除");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<RateInfo> modelBuilder);
}
