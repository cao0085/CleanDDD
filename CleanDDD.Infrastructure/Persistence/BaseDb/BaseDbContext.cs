using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using CleanDDD.Infrastructure.Persistence.BaseDb.Models;

namespace CleanDDD.Infrastructure.Persistence.BaseDb;

public partial class BaseDbContext : DbContext, IBaseDbContext
{
    public BaseDbContext(DbContextOptions<BaseDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CompanyInfo> CompanyInfo { get; set; }

    public virtual DbSet<UserComanyMap> UserComanyMap { get; set; }

    public virtual DbSet<UserInfo> UserInfo { get; set; }

    public virtual DbSet<OutboxMessage> OutboxMessage { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Configurations.CompanyInfoConfiguration());

        modelBuilder.ApplyConfiguration(new Configurations.UserComanyMapConfiguration());

        modelBuilder.ApplyConfiguration(new Configurations.UserInfoConfiguration());

        modelBuilder.ApplyConfiguration(new Configurations.OutboxMessageConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

public interface IBaseDbContext
{
    public DbSet<CompanyInfo> CompanyInfo { get; set; }
    public DbSet<UserComanyMap> UserComanyMap { get; set; }
    public DbSet<UserInfo> UserInfo { get; set; }

    public DbSet<OutboxMessage> OutboxMessage { get; set; }
}
