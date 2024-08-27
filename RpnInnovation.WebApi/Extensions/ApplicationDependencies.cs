using RpnInnovation.Application.OtherInterfaces;
using RpnInnovation.Infrastructure.Persistence;

namespace RpnInnovation.WebApi.Extensions
{
    public static class ApplicationDependencies
    {
        public static IServiceCollection AddValidators(this IServiceCollection services)
        {

        }

        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddTransient<ICustomerReadRepository, CustomerReadRepository>();

            return services;
        }
    }
}
