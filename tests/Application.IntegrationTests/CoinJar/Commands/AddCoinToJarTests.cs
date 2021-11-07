using CoinJarGK.Application.CoinJar.Commands.AddCoinToJar;
using CoinJarGK.Application.CoinJar.Queries.GetCoinJarTotalAmount;
using CoinJarGK.Application.Common.Exceptions;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;

namespace CoinJarGK.Application.IntegrationTests.CoinJar.Commands
{
    using static Testing;

    public class AddCoinToJarTests : TestBase
    {
        [Test]
        public void ShouldRequireVolumeGreaterThanZero()
        {
            var command = new AddCoinToJarCommand { Amount = 10, Volume = 0 };

            FluentActions.Invoking(() =>
                SendMediatorRequestAsync(command)).Should().ThrowAsync<CustomValidationException>();
        }

        [Test]
        public void ShouldRequireAmountGreaterThanZero()
        {
            var command = new AddCoinToJarCommand { Amount = 0, Volume = 10 };

            FluentActions.Invoking(() =>
                SendMediatorRequestAsync(command)).Should().ThrowAsync<CustomValidationException>();
        }

        [Test]
        public async Task ShouldThrowVolumeExceedException()
        {
            // Max volume = 42
            await SendMediatorRequestAsync(new AddCoinToJarCommand { Amount = 10, Volume = 40 });
            await SendMediatorRequestAsync(new AddCoinToJarCommand { Amount = 5, Volume = 2 });

            var command = new AddCoinToJarCommand { Amount = 1, Volume = 1 };

            await FluentActions.Invoking(() =>
                SendMediatorRequestAsync(command)).Should().ThrowAsync<CoinJarVolumeExceedException>();
        }

        [Test]
        public async Task ShouldAddCoin() 
        {
            var command = new AddCoinToJarCommand { Amount = 10, Volume = 2 };

            await SendMediatorRequestAsync(command);

            var jarDetails = await SendMediatorRequestAsync(new GetCoinJarTotalAmountQuery());

            jarDetails.TotalAmount.Should().Be(command.Amount);
        }
    }
}
