namespace CoinJarGK.Application.Common.Interfaces
{
    public interface ICoinJarDetail
    {
        decimal TotalVolume { get; set; }
        decimal TotalAmount { get; set; }
        int TotalCoins { get; set; }
    }
}
