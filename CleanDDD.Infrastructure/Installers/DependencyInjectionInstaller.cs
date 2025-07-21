using CleanDDD.Application.Companies;
using CleanDDD.Application.Shared;
using CleanDDD.Application.Users.CreateUser;
using CleanDDD.Domain;
using CleanDDD.Domain.Companies;
using CleanDDD.Domain.Users;
using CleanDDD.Infrastructure.Authentication;
using CleanDDD.Infrastructure.Exceptions;
using CleanDDD.Infrastructure.Shared;
using CleanDDD.TestDoubles.PasswordHash;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanDDD.Domain.PasswordHash;
using CleanDDD.Infrastructure.Persistence.Repository;
using CleanDDD.Application.Common;

namespace CleanDDD.Infrastructure.Installers
{
    public static class DependencyInjectionInstaller
    {
        public static void InstallDependencyInjectionRegistrations(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpContextAccessor();

            // Repository here:
            //builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            //builder.Services.AddScoped<IOrderRepository, OrderRepository>();
            builder.Services.AddHostedService<OutboxDispatcherBackgroundService>();
            builder.Services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            //builder.Services.AddTransient<IDomainEventDispatcher, DomainEventDispatcher>();
            //builder.Services.AddHostedService<DomainEventsProcessor>();
            //builder.Services.AddHostedService<IntegrationEventsProcessor>();

            //builder.Services.AddTransient<CustomerCreatedEventMapper>();
            //builder.Services.AddSingleton<EventMapperFactory>(provider =>
            //{
            //    var mappers = new Dictionary<Type, IEventMapper>
            //    {
            //        { typeof(CustomerCreatedDomainEvent), provider.GetRequiredService<CustomerCreatedEventMapper>() },
            //    };

            //    return new EventMapperFactory(mappers);
            //});
            builder.Services.AddValidatorsFromAssemblyContaining<IApplicationValidator>(ServiceLifetime.Transient);
            builder.Services.AddProblemDetails();
            builder.Services.AddExceptionHandler<CommandValidationExceptionHandler>();
            builder.Services.AddSingleton<ICacheService, CacheService>();
            //builder.Services.AddScoped<IEmailService, EmailService>();
            //builder.Services.AddScoped<IEmailTemplateFactory, EmailTemplateFactory>();
            //builder.Services.AddScoped<OrderDomainService>();
            //builder.Services.AddScoped<IOrderReadService, OrderReadService>();
            //builder.Services.AddScoped<ICustomerReadService, CustomerReadService>();
            //builder.Services.AddScoped<IAdminReadService, AdminReadService>();
            builder.Services.AddScoped<IAuthenticationService, JwtAuthenticationService>();

            builder.Services.AddScoped<ICompanyRepository, CompanyRepository>();
            builder.Services.AddScoped<ICompanyReadRepository, CompanyReadRepository>();
            builder.Services.AddScoped<ICompanyReadRepository, CompanyReadRepository>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddSingleton<IPasswordHasher, FakePasswordHasher>();
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IOutboxRepository,OutboxRepository>();


        }

    }
}
