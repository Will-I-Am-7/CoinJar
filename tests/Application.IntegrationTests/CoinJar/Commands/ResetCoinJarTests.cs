using CoinJarGK.Application.CoinJar.Commands.AddCoinToJar;
using CoinJarGK.Application.CoinJar.Commands.ResetCoinJar;
using CoinJarGK.Application.CoinJar.Queries.GetCoinJarTotalAmount;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace CoinJarGK.Application.IntegrationTests.CoinJar.Commands
{
    using static Testing;

    public class ResetCoinJarTests : TestBase
    {
        [Test]
        public async Task ShouldResetCoinJar() 
        {
            await SendMediatorRequestAsync(new AddCoinToJarCommand { Amount = 10, Volume = 40 });
            await SendMediatorRequestAsync(new AddCoinToJarCommand { Amount = 5, Volume = 2 });

            await SendMediatorRequestAsync(new ResetCoinJarCommand());

            var jarDetails = await SendMediatorRequestAsync(new GetCoinJarTotalAmountQuery());

            jarDetails.TotalAmount.Should().Be(0);
        }
    }
}
