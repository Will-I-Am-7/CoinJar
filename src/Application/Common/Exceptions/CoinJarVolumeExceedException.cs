using System;

namespace CoinJarGK.Application.Common.Exceptions
{
    public class CoinJarVolumeExceedException : Exception
    {
        public CoinJarVolumeExceedException(string message) : base(message) { }
    }
}
