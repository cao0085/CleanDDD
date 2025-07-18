using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanDDD.Infrastructure.Persistence.BaseDb.Models;

namespace CleanDDD.Infrastructure.Persistence.BaseDb.Configurations;

public partial class UserInfoConfiguration : IEntityTypeConfiguration<UserInfo>
{
    public void Configure(EntityTypeBuilder<UserInfo> entity)
    {
        entity.Property(e => e.UserInfoId).HasComment("使用者自增長識別");
        entity.Property(e => e.Email).HasMaxLength(50);
        entity.Property(e => e.CreatedAt)
            .HasComment("建立時間")
            .HasColumnType("datetime");
        entity.Property(e => e.Name)
            .HasMaxLength(50)
            .HasComment("帳號");
        entity.Property(e => e.Nickname)
            .HasMaxLength(50)
            .HasComment("人員名稱");
        entity.Property(e => e.PasswordHash)
            .HasMaxLength(100)
            .HasComment("密碼");
        entity.Property(e => e.RefreshToken).HasMaxLength(500);
        entity.Property(e => e.RefreshTokenExpires).HasColumnType("datetime");
        entity.Property(e => e.State).HasComment("狀態\r\n0: 無效\r\n1: 生效\r\n9: 刪除");
        entity.Property(e => e.Type).HasComment("類型\r\n1: 系統管理員\r\n2: 軟體人員\r\n11: 企業帳號\r\n21: 工程人員\r\n31: 現場人員");
        entity.Property(e => e.UpdatedAt)
            .HasComment("更新時間")
            .HasColumnType("datetime");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<UserInfo> modelBuilder);
}
