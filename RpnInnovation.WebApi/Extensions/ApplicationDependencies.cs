using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using RpnInnovation.Application.Features.Account.Interfaces;
using RpnInnovation.Application.Features.Email;
using RpnInnovation.Application.OtherInterfaces;
using RpnInnovation.Application.Validations;
using RpnInnovation.Domain.AppSettings;
using RpnInnovation.Infrastructure.Integrations.Email;
using RpnInnovation.Infrastructure.Persistence;
using RpnInnovation.Infrastructure.Services;
using System;
using AppDBContext = RpnInnovation.Infrastructure.Persistence.AppDBContext;

namespace RpnInnovation.WebApi.Extensions
{
    public static class ApplicationDependencies
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<AccountCreationRequestValidator>();
            services.AddFluentValidationAutoValidation();
            return services;
        }

        public static IServiceCollection AddRepository(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddDbContext<AppDBContext>(options =>
                    options.UseSqlServer(builder.Configuration.GetConnectionString("Database"))
            );

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();

            return services;
        }

        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IAccountService, AccountService>();
            
            return services;
        }
        public static IServiceCollection AddIntegrationServices(this IServiceCollection services)
        {
            services.AddScoped<IEmailService, EmailService>();

            return services;
        }

        public static IServiceCollection AddAppSettings(this IServiceCollection services, IConfiguration configuration) {

            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            return services;
        }
    }
}
