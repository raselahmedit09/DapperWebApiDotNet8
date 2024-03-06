using DapperAPI.Repository;

namespace DapperAPI.Extensions
{
    public static class AplicatonServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            return services;
        }
    }
}
