using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CleanDDD.Infrastructure.Persistence.CompanyDb.Models;

namespace CleanDDD.Infrastructure.Persistence.CompanyDb.Configurations;

public partial class UserSiteMapConfiguration : IEntityTypeConfiguration<UserSiteMap>
{
    public void Configure(EntityTypeBuilder<UserSiteMap> entity)
    {
        entity.HasKey(e => new { e.UserInfoId, e.SiteInfoId });

        entity.Property(e => e.UserInfoId).HasComment("使用者ID");
        entity.Property(e => e.SiteInfoId).HasComment("場地ID");

        OnConfigurePartial(entity);
    }

    partial void OnConfigurePartial(EntityTypeBuilder<UserSiteMap> modelBuilder);
}
