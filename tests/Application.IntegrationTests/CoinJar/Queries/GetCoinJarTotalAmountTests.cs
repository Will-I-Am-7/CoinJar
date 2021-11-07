using CoinJarGK.Application.CoinJar.Commands.AddCoinToJar;
using CoinJarGK.Application.CoinJar.Queries.GetCoinJarTotalAmount;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace CoinJarGK.Application.IntegrationTests.CoinJar.Queries
{
    using static Testing;

    public class GetCoinJarTotalAmountTests : TestBase
    {
        [Test]
        public async Task ShouldGetTotalAmount() 
        {
            await SendMediatorRequestAsync(new AddCoinToJarCommand { Amount = 10, Volume = 5 });
            await SendMediatorRequestAsync(new AddCoinToJarCommand { Amount = 5, Volume = 2 });
            await SendMediatorRequestAsync(new AddCoinToJarCommand { Amount = 10, Volume = 7 });

            var jarDetails = await SendMediatorRequestAsync(new GetCoinJarTotalAmountQuery());

            jarDetails.TotalAmount.Should().Be(25);
        }
    }
}
