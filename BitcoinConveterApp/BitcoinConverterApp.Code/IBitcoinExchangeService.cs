using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitcoinConverterApp.Code
{
    public interface IBitcoinExchangeService
    {
        Task<decimal> FetchCurrencyRate(string currencyCode);
        Task<decimal> GetDollarRateFromBitcoins(string currencyCode, int coins);
    }
}
