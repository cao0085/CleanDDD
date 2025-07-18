using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CleanDDD.Infrastructure.Persistence.CompanyDb.Models;

namespace CleanDDD.Infrastructure.Persistence.CompanyDb;

public partial class CompanyDbContext : DbContext, ICompanyDbContext
{
    public CompanyDbContext(DbContextOptions<CompanyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MachineInfo> MachineInfo { get; set; }

    public virtual DbSet<RateDetail> RateDetail { get; set; }

    public virtual DbSet<RateInfo> RateInfo { get; set; }

    public virtual DbSet<RoadSection> RoadSection { get; set; }

    public virtual DbSet<RoadSideOrder> RoadSideOrder { get; set; }

    public virtual DbSet<RoadSideOrderDetail> RoadSideOrderDetail { get; set; }

    public virtual DbSet<SiteInfo> SiteInfo { get; set; }

    public virtual DbSet<UserSiteMap> UserSiteMap { get; set; }

    public virtual DbSet<VenderInterface> VenderInterface { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Configurations.MachineInfoConfiguration());

        modelBuilder.ApplyConfiguration(new Configurations.RateDetailConfiguration());

        modelBuilder.ApplyConfiguration(new Configurations.RateInfoConfiguration());

        modelBuilder.ApplyConfiguration(new Configurations.RoadSectionConfiguration());

        modelBuilder.ApplyConfiguration(new Configurations.RoadSideOrderConfiguration());

        modelBuilder.ApplyConfiguration(new Configurations.RoadSideOrderDetailConfiguration());

        modelBuilder.ApplyConfiguration(new Configurations.SiteInfoConfiguration());

        modelBuilder.ApplyConfiguration(new Configurations.UserSiteMapConfiguration());

        modelBuilder.ApplyConfiguration(new Configurations.VenderInterfaceConfiguration());
        modelBuilder.HasSequence("Sequence-RSOrder");
        modelBuilder.HasSequence("Sequence-RSOrderDetail");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

public interface ICompanyDbContext
{
    public DbSet<MachineInfo> MachineInfo { get; set; }
    public DbSet<RateDetail> RateDetail { get; set; }
    public DbSet<RateInfo> RateInfo { get; set; }
    public DbSet<RoadSection> RoadSection { get; set; }
    public DbSet<RoadSideOrder> RoadSideOrder { get; set; }
    public DbSet<RoadSideOrderDetail> RoadSideOrderDetail { get; set; }
    public DbSet<SiteInfo> SiteInfo { get; set; }
    public DbSet<UserSiteMap> UserSiteMap { get; set; }
    public DbSet<VenderInterface> VenderInterface { get; set; }
}
