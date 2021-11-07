using CoinJarGK.Application.Common.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoinJarGK.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CoinJarConfiguration>(configuration.GetSection(nameof(CoinJarConfiguration)));

            return services;
        }
    }
}
