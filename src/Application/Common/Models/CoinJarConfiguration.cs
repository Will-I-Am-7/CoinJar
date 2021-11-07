using CoinJarGK.Application.Common.Enums;
using System.Collections.Generic;

namespace CoinJarGK.Application.Common.Models
{
    public class CoinJarConfiguration
    {
        public decimal MaxVolume { get; set; }
        public IList<USCoinConfiguration> USCoins { get; set; }
    }

    public class USCoinConfiguration
    {
        public USCoinDenomination Denomination { get; set; }
        public decimal Volume { get; set; }
    }
}
