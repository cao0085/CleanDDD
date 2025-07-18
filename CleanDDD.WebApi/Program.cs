using CleanDDD.Infrastructure.Installers;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.InstallAuthentication();
// Add services to the container.
builder.InstallEntityFramework();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.InstallSwagger();
builder.InstallApplicationSettings();
builder.InstallMediatR();

// 可替換分散式快取 (Redis or SQL Server)
builder.Services.AddDistributedMemoryCache();

builder.InstallDependencyInjectionRegistrations();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseCors(CorsInstaller.DefaultCorsPolicyName);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
