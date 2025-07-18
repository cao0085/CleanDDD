using CleanDDD.Infrastructure.Persistence.BaseDb;
using CleanDDD.Infrastructure.Persistence.CompanyDb;
using CleanDDD.Infrastructure.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanDDD.Infrastructure.Installers
{
    public static class EntityFrameworkInstaller
    {
        public static void InstallEntityFramework(this WebApplicationBuilder builder)
        {
            var appSettings = builder.Configuration.GetSection(nameof(AppSettings)).Get<AppSettings>();
            if (appSettings != null)
            {
                var msSqlSettings = appSettings.ConnectionStrings;
                builder.Services.AddDbContext<BaseDbContext>(options => options.UseSqlServer(msSqlSettings.BaseConfig));
                builder.Services.AddScoped<IBaseDbContext>(provider => provider.GetService<BaseDbContext>()!);

                builder.Services.AddScoped<Func<string, CompanyDbContext>>(provider => connStringName =>
                {
                    var config = provider.GetRequiredService<IConfiguration>();
                    var optionsBuilder = new DbContextOptionsBuilder<CompanyDbContext>();
                    optionsBuilder.UseSqlServer(
                        config.GetConnectionString(connStringName)
                    );
                    return new CompanyDbContext(optionsBuilder.Options);
                });
            }
        }

        //public static void SeedDatabase(BaseDbContext appDbContext)
        //{
        //    appDbContext.Database.Migrate();
        //}
    }
}
