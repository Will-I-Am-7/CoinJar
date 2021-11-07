using CoinJarGK.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CoinJarGK.Application.CoinJar.Commands.ResetCoinJar
{
    public class ResetCoinJarCommand : IRequest { }

    class ResetCoinJarCommandHandler : IRequestHandler<ResetCoinJarCommand>
    {
        private readonly ICoinJar _coinJar;

        public ResetCoinJarCommandHandler(ICoinJar coinJar)
        {
            _coinJar = coinJar;
        }

        #pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<Unit> Handle(ResetCoinJarCommand request, CancellationToken cancellationToken)
        {
            _coinJar.Reset();

            return Unit.Value;
        }
        #pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    }
}
