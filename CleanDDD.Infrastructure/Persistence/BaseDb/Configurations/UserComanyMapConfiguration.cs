using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanDDD.Infrastructure.Persistence.BaseDb.Models;

namespace CleanDDD.Infrastructure.Persistence.BaseDb.Configurations;

public partial class UserComanyMapConfiguration : IEntityTypeConfiguration<UserComanyMap>
{
    public void Configure(EntityTypeBuilder<UserComanyMap> entity)
    {
        entity.HasKey(e => new { e.UserInfoId, e.CompanyInfoId });

        entity.Property(e => e.UserInfoId).HasComment("使用者自增長識別");
        entity.Property(e => e.CompanyInfoId).HasComment("企業自增長識別");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<UserComanyMap> modelBuilder);
}
