using System;
namespace BitcoinConverterApp.Code;

public class CurrencyRateService
{


    public CurrencyRateService()
    {

    }

    public async Task<int> FetchRate(string currencyCode)
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

}
