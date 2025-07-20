using System;
namespace BitcoinConverterApp.Code;

public class CurrencyRateService
{


    public CurrencyRateService()
    {

    }

    public async Task<int> FetchCurrencyRate(string currencyCode)
    {

        if (currencyCode.Equals("USD"))
        {
            return 98;
        }
        else if (currencyCode.Equals("INR"))
        {
            return 86;
        }

        return 10;
    }

    public async Task<int> GetDollarRateFromBitcoins(string currencyCode, int coins)
    {
        var totalDollars = await FetchCurrencyRate(currencyCode) * coins;
        return totalDollars;
    }

}
