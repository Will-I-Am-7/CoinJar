using CoinJarGK.Application.Common.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CoinJarGK.Application.CoinJar.Queries.GetCoinJarTotalAmount
{
    public class GetCoinJarTotalAmountQuery : IRequest<GetCoinJarTotalAmountDto> { }

    class GetCoinJarTotalAmountQueryHandler : IRequestHandler<GetCoinJarTotalAmountQuery, GetCoinJarTotalAmountDto>
    {
        private readonly ICoinJar _coinJar;

        public GetCoinJarTotalAmountQueryHandler(ICoinJar coinJar)
        {
            _coinJar = coinJar;
        }

        #pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<GetCoinJarTotalAmountDto> Handle(GetCoinJarTotalAmountQuery request, CancellationToken cancellationToken)
        {
            decimal totalAmount = _coinJar.GetTotalAmount();

            return new GetCoinJarTotalAmountDto { TotalAmount = totalAmount };
        }
        #pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    }
}
