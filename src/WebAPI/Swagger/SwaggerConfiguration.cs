using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;

namespace CoinJarGK.WebAPI.Swagger
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "CoinJarGK WebAPI v1", Version = "v1" });
                options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "CoinJarGK.WebAPI.xml"));
            });

            return services;
        }
    }
}
