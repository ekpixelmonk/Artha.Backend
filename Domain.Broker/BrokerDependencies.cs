using Domain.Broker.Data;
using Domain.Broker.Features.GetZerodhaConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain.Broker
{
    public static class BrokerDependencies
    {
        public static IServiceCollection AddBrokerDomain(this IServiceCollection services, IConfiguration configuration)
        {
            // Read the connection string from the environment variable
            var connectionString = configuration["ARTHA_TEST_DB_CONNECTION_STRING"];
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Database connection string 'ARTHA_TEST_DB_CONNECTION_STRING' is not set.");
            }

            // 1. Add the DbContext for the Broker domain
            services.AddDbContext<BrokerDbContext>(options => options.UseSqlServer(connectionString));

            // 2. Register feature handlers
            services.AddScoped<GetZerodhaConfigurationHandler>();

            // ... register other handlers and services specific to this domain
            return services;
        }
    }
}
