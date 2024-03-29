﻿using CoinJarGK.Application.Common.Exceptions;
using CoinJarGK.Application.Common.Interfaces;
using CoinJarGK.Application.Common.Models;
using Microsoft.Extensions.Options;

namespace CoinJarGK.Infrastructure.Services
{
    public class CoinJar : ICoinJar
    {
        private readonly ICoinJarPersistence _persistence;

        private readonly decimal _maxVolume;

        public CoinJar(ICoinJarPersistence persistence, IOptions<CoinJarConfiguration> options)
        {
            _maxVolume = options.Value.MaxVolume;
            _persistence = persistence;
        }

        public void AddCoin(ICoin coin)
        {
            var coinDetail = _persistence.GetDetail();

            if (coinDetail.TotalVolume + coin.Volume > _maxVolume)
            {
                throw new CoinJarVolumeExceedException(_maxVolume);
            }

            coinDetail.TotalAmount += coin.Amount;
            coinDetail.TotalVolume += coin.Volume;
            coinDetail.TotalCoins++;

            _persistence.UpdateDetail(coinDetail);
        }

        public decimal GetTotalAmount()
        {
            var coinDetail = _persistence.GetDetail();
            return coinDetail.TotalAmount;
        }

        public void Reset()
        {
            _persistence.UpdateDetail(new CoinJarDetail());
        }
    }
}
