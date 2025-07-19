using Xunit;
using BitcoinConverterApp.Code;

namespace BitcoinConverterApp.Tests;

public class CurrencyRateServiceTests
{
    [Fact]
    public void FetchRate_USD_ReturnsExpectedRate()
    {
        //arrange
        var rateService = new CurrencyRateService();

        //act 
        var acutalRate = rateService.FetchRate("USD");

        //assert
        var expectedRate = 98;

        Assert.Equal(expectedRate,acutalRate);

    }
}