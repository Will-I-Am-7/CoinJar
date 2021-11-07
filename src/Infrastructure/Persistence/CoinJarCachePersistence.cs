using CoinJarGK.Application.Common.Interfaces;
using CoinJarGK.Application.Common.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text;

namespace CoinJarGK.Infrastructure.Persistence
{
    public class CoinJarCachePersistence : ICoinJarPersistence
    {
        private readonly IDistributedCache _cache;
        private const string _cacheKey = "coinjardcs";

        public CoinJarCachePersistence(IDistributedCache cache)
        {
            _cache = cache;
        }

        public CoinJarDetail GetDetail()
        {
            var cachedJarBytes = _cache.Get(_cacheKey);
            if (cachedJarBytes == null || cachedJarBytes.Length == 0)
            {
                return new CoinJarDetail();
            }

            var cachedJar = JsonConvert.DeserializeObject<CoinJarDetail>(Encoding.Default.GetString(cachedJarBytes));
            return cachedJar;
        }

        public void UpdateDetail(CoinJarDetail coinDetail)
        {
            var serializedJar = Encoding.Default.GetBytes(JsonConvert.SerializeObject(coinDetail));
            _cache.Set(_cacheKey, serializedJar);
        }
    }
}
