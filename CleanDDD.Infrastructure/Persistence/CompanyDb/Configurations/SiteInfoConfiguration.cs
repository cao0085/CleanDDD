using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanDDD.Infrastructure.Persistence.CompanyDb.Models;

namespace CleanDDD.Infrastructure.Persistence.CompanyDb.Configurations;

public partial class SiteInfoConfiguration : IEntityTypeConfiguration<SiteInfo>
{
    public void Configure(EntityTypeBuilder<SiteInfo> entity)
    {
        entity.HasKey(e => e.SiteInfoId).HasName("PK_Site");

        entity.Property(e => e.SiteInfoId).HasComment("場地ID");
        entity.Property(e => e.Address)
            .HasMaxLength(200)
            .HasComment("地址");
        entity.Property(e => e.Authority)
            .HasMaxLength(30)
            .HasComment("業管機關代碼");
        entity.Property(e => e.ChargeInfoParam).HasComment("充電資訊上傳參數\r\nJson 字串");
        entity.Property(e => e.InsertTime)
            .HasComment("建立時間")
            .HasColumnType("datetime");
        entity.Property(e => e.LicenseName)
            .HasMaxLength(100)
            .HasComment("停車證名稱");
        entity.Property(e => e.ManagementType).HasComment("管理類型\r\n0：無人場\r\n1：有人場\r\n2：路邊停車");
        entity.Property(e => e.Memo)
            .HasMaxLength(200)
            .HasComment("備註");
        entity.Property(e => e.Name)
            .HasMaxLength(100)
            .HasComment("場地名稱");
        entity.Property(e => e.Outsource).HasComment("委外類型\r\n0: 不適用\r\n1: 權力委外\r\n2: 勞務委外");
        entity.Property(e => e.PayDeadline).HasComment("繳費期限(天)\r\n路邊停車開單後幾天內須繳費\r\n-1: 無限制");
        entity.Property(e => e.SerialNo)
            .HasMaxLength(50)
            .HasComment("自定義代碼");
        entity.Property(e => e.State).HasComment("狀態\r\n0: 無效\r\n1: 生效\r\n9: 刪除");
        entity.Property(e => e.Tel)
            .HasMaxLength(50)
            .HasComment("連絡電話");
        entity.Property(e => e.UpdateTime)
            .HasComment("更新時間")
            .HasColumnType("datetime");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<SiteInfo> modelBuilder);
}
