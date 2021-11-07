using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using CoinJarGK.WebAPI;
using Moq;
using MediatR;
using System.Threading.Tasks;
using CoinJarGK.Application.CoinJar.Commands.ResetCoinJar;

namespace CoinJarGK.Application.IntegrationTests
{
    [SetUpFixture]
    public class Testing
    {
        private static IConfigurationRoot _configuration;
        private static IServiceScopeFactory _scopeFactory;

        [OneTimeSetUp]
        public void RunBeforeAnyTests()
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", true, true)
            .AddEnvironmentVariables();

            _configuration = builder.Build();

            var startup = new Startup(_configuration);

            var services = new ServiceCollection();

            services.AddSingleton(Mock.Of<IWebHostEnvironment>(w =>
                w.EnvironmentName == "Development" &&
                w.ApplicationName == "CoinJarGK.WebAPI"));

            services.AddLogging();

            startup.ConfigureServices(services);

            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();
        }

        public static async Task<TResponse> SendMediatorRequestAsync<TResponse>(IRequest<TResponse> request)
        {
            using var scope = _scopeFactory.CreateScope();

            var mediator = scope.ServiceProvider.GetService<ISender>();

            return await mediator.Send(request);
        }

        public static async Task ResetJar() 
        {
            await SendMediatorRequestAsync(new ResetCoinJarCommand());
        }

        [OneTimeTearDown]
        public void RunAfterAnyTests()
        {
        }
    }
}
