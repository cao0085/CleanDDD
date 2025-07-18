using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanDDD.Infrastructure.Persistence.CompanyDb.Models;

namespace CleanDDD.Infrastructure.Persistence.CompanyDb.Configurations;

public partial class VenderInterfaceConfiguration : IEntityTypeConfiguration<VenderInterface>
{
    public void Configure(EntityTypeBuilder<VenderInterface> entity)
    {
        entity.Property(e => e.VenderInterfaceId).HasComment("ID");
        entity.Property(e => e.InsertTime)
            .HasComment("建立時間")
            .HasColumnType("datetime");
        entity.Property(e => e.JsonData).HasComment("參數資料");
        entity.Property(e => e.Name)
            .HasMaxLength(50)
            .HasComment("名稱");
        entity.Property(e => e.Type).HasComment("類型");
        entity.Property(e => e.UpdateTime)
            .HasComment("更新時間")
            .HasColumnType("datetime");
        entity.Property(e => e.VenderId).HasComment("廠商ID (CompanyID)");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<VenderInterface> modelBuilder);
}
