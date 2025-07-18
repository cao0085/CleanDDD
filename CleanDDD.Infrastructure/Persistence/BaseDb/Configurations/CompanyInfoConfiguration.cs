using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanDDD.Infrastructure.Persistence.BaseDb.Models;

namespace CleanDDD.Infrastructure.Persistence.BaseDb.Configurations;

public partial class CompanyInfoConfiguration : IEntityTypeConfiguration<CompanyInfo>
{
    public void Configure(EntityTypeBuilder<CompanyInfo> entity)
    {
        entity.Property(e => e.CompanyInfoId).HasComment("企業自增長識別");
        entity.Property(e => e.Address)
            .HasMaxLength(200)
            .HasComment("完整地址");
        entity.Property(e => e.EnName)
            .HasMaxLength(100)
            .HasComment("英文名稱");
        entity.Property(e => e.CreatedAt)
            .HasComment("新增時間")
            .HasColumnType("datetime");
        entity.Property(e => e.Name)
            .HasMaxLength(100)
            .HasComment("企業名稱");
        entity.Property(e => e.RegisterNo)
            .HasMaxLength(50)
            .HasComment("統編");
        entity.Property(e => e.SerialNo)
            .HasMaxLength(100)
            .HasComment("自定義編碼");
        entity.Property(e => e.ShortName)
            .HasMaxLength(100)
            .HasComment("簡稱");
        entity.Property(e => e.State).HasComment("狀態\r\n0: 失效\r\n1: 生效\r\n9: 刪除");
        entity.Property(e => e.TaxIDNo)
            .HasMaxLength(30)
            .HasComment("稅籍編碼");
        entity.Property(e => e.Tel)
            .HasMaxLength(30)
            .HasComment("連絡電話");
        entity.Property(e => e.Type).HasComment("類型\r\n1: 企業\r\n2: 廠商");
        entity.Property(e => e.UpdatedAt)
            .HasComment("更新時間")
            .HasColumnType("datetime");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<CompanyInfo> modelBuilder);
}
