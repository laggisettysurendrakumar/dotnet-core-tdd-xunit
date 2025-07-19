using System;
namespace BitcoinConverterApp.Code;

public class CurrencyRateService
{


public CurrencyRateService(){

}

public double FetchRate(string currencyCode){

    if(currencyCode.Equals("USD")){
        return 98;
    }

    return 10;
}

}
