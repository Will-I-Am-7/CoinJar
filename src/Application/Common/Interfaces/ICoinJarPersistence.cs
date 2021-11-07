using CoinJarGK.Application.Common.Models;

namespace CoinJarGK.Application.Common.Interfaces
{
    public interface ICoinJarPersistence
    {
        CoinJarDetail GetDetail();
        void UpdateDetail(CoinJarDetail coinDetail);
    }
}
