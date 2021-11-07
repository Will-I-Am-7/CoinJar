using CoinJarGK.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CoinJarGK.Application.CoinJar.Commands.AddCoinToJar
{
    public class AddCoinToJarCommand : IRequest, ICoin
    {
        public decimal Amount { get; set; }
        public decimal Volume { get; set; }
    }

    class AddCoinToJarCommandHandler : IRequestHandler<AddCoinToJarCommand>
    {
        private readonly ICoinJar _coinJar;

        public AddCoinToJarCommandHandler(ICoinJar coinJar)
        {
            _coinJar = coinJar;
        }

        #pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<Unit> Handle(AddCoinToJarCommand request, CancellationToken cancellationToken)
        {
            _coinJar.AddCoin(request);

            return Unit.Value;
        }
        #pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    }
}
