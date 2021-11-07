namespace CoinJarGK.Application.Common.Interfaces
{
    public interface ICoinJarPersistence
    {
        ICoinJarDetail GetDetail();
        void UpdateDetail(ICoinJarDetail coinDetail);
    }
}
