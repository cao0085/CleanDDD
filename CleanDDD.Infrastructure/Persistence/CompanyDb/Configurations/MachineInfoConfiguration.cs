using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanDDD.Infrastructure.Persistence.CompanyDb.Models;

namespace CleanDDD.Infrastructure.Persistence.CompanyDb.Configurations;

public partial class MachineInfoConfiguration : IEntityTypeConfiguration<MachineInfo>
{
    public void Configure(EntityTypeBuilder<MachineInfo> entity)
    {
        entity.HasKey(e => e.MachineInfoId).HasName("PK_MachineSet");

        entity.Property(e => e.MachineInfoId).HasComment("ID");
        entity.Property(e => e.ChargesType).HasComment("設備類型\r\n10:路邊PDA\r\n11:路邊車辨柱");
        entity.Property(e => e.PDANo)
            .HasMaxLength(100)
            .HasComment("PDA辨識碼");
        entity.Property(e => e.SerialNo)
            .HasMaxLength(100)
            .HasComment("自定義機號");
        entity.Property(e => e.SiteInfoId).HasComment("場地ID");
        entity.Property(e => e.State).HasComment("狀態\r\n0：無效\r\n1：生效\r\n9：刪除");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<MachineInfo> modelBuilder);
}
