using CleanDDD.Application.Authentication.LoginUser;
using CleanDDD.Application.Authentication.RefreshToken;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace CleanDDD.Infrastructure.Installers;

public static class MediatRInstaller
{
    //public static void InstallMediatR(this WebApplicationBuilder builder)
    //{
    //    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<LoginUserCommand>());
    //    builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<RefreshTokenCommand>());
    //}
    public static void InstallMediatR(this WebApplicationBuilder builder)
    {
        builder.Services.AddMediatR(cfg =>
        {
            cfg.RegisterServicesFromAssemblyContaining<LoginUserCommand>();
            cfg.RegisterServicesFromAssemblyContaining<RefreshTokenCommand>();
        });
    }

}
