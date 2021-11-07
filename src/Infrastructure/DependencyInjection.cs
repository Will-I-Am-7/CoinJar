using CoinJarGK.Application.Common.Interfaces;
using CoinJarGK.Application.Common.Models;
using CoinJarGK.Infrastructure.Persistence;
using CoinJarGK.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoinJarGK.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDistributedMemoryCache();

            services.Configure<CoinJarConfiguration>(configuration.GetSection(nameof(CoinJarConfiguration)));

            services.AddSingleton<ICoinJarPersistence, CoinJarCachePersistence>();
            services.AddSingleton<ICoinJar, CoinJar>();

            return services;
        }
    }
}
