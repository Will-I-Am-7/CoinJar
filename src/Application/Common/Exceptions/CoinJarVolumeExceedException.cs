using System;
using System.Collections.Generic;

namespace CoinJarGK.Application.Common.Exceptions
{
    public class CoinJarVolumeExceedException : Exception
    {
        public CoinJarVolumeExceedException(decimal volume) : base($"Coin cannot be added as the volume would then exceed {volume} fluid ounces") 
        {
            Details = new Dictionary<string, string[]>
            {
                { "Volume exceeded maximum volume of the jar", new string[] { $"{volume}" } }
            };
        }

        public IDictionary<string, string[]> Details { get; }
    }
}
