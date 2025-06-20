using Microsoft.Extensions.DependencyInjection;
using Artha.Backend.Services;
using Artha.Backend.Services.Interface;
using Artha.Backend.Domain.Contract.Interface;
using Artha.Backend.Persistence.Repository;

namespace Artha.Backend.DependencyInjection
{
    /// <summary>
    /// Provides extension methods for registering application services.
    /// </summary>
    public static class DependencyInjectionRegistrar
    {
        /// <summary>
        /// Registers all application services for dependency injection.
        /// </summary>
        /// <param name="services">The IServiceCollection to add services to.</param>
        public static void AddServices(this IServiceCollection services)
        {
            // Register ZerodhaConfig services
            services.AddScoped<IZerodhaConfigService, ZerodhaConfigService>();
            services.AddScoped<IZerodhaTradeableInstrumentService, ZerodhaTradeableInstrumentService>();
            // ...register other services here as needed
        }

        /// <summary>
        /// Registers all repositories for dependency injection.
        /// </summary>
        /// <param name="services">The IServiceCollection to add repositories to.</param>
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IZerodhaConfigRepository, ZerodhaConfigRepository>();
            services.AddScoped<IZerodhaTradeableInstrumentRepository, ZerodhaTradeableInstrumentRepository>();
            // ...register other repositories here as needed
        }
    }
}
