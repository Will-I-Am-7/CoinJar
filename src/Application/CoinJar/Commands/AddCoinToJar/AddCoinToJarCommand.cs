using CoinJarGK.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CoinJarGK.Application.CoinJar.Commands.AddCoinToJar
{
    public class AddCoinToJarCommand : IRequest<AddCoinToJarDto>, ICoin
    {
        public decimal Amount { get; set; }
        public decimal Volume { get; set; }
    }

    class AddCoinToJarCommandHandler : IRequestHandler<AddCoinToJarCommand, AddCoinToJarDto>
    {
        private readonly ICoinJar _coinJar;
        private readonly ICoinJarPersistence _coinJarPersistence;

        public AddCoinToJarCommandHandler(ICoinJar coinJar, ICoinJarPersistence coinJarPersistence)
        {
            _coinJar = coinJar;
            _coinJarPersistence = coinJarPersistence;
        }

        #pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<AddCoinToJarDto> Handle(AddCoinToJarCommand request, CancellationToken cancellationToken)
        {
            _coinJar.AddCoin(request);

            var jarDetail = _coinJarPersistence.GetDetail();

            return new AddCoinToJarDto
            {
                TotalAmount = jarDetail.TotalAmount,
                TotalCoins = jarDetail.TotalCoins,
                TotalVolume = jarDetail.TotalVolume
            };
        }
        #pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    }
}
