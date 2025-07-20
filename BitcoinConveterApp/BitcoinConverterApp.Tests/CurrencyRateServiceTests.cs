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
        var acutalRate = rateService.FetchCurrencyRate("USD");

        //assert
        var expectedRate = 98;

        Assert.Equal(expectedRate, acutalRate.Result);

    }

    [Fact]
    public void FetchRate_INR_ReturnsExpectedRate()
    {
        //arrange
        var rateService = new CurrencyRateService();

        //act 
        var acutalRate = rateService.FetchCurrencyRate("INR");

        //assert
        var expectedRate = 86;

        Assert.Equal(expectedRate, acutalRate.Result);

    }

    [Theory] //[Theory] allows you to parameterize your tests and reuse the same logic for different inputs. 
    [InlineData("USD", 1, 98)]
    [InlineData("USD", 2, 196)]
    [InlineData("INR", 1, 86)]
    [InlineData("INR", 2, 172)]
    public void ConvertBitcoins_BitcoinsToCurrency_ReturnsCurrency(string currency, int coins, int convertedDollars)
    {
        // Arrange  
        var rateService = new CurrencyRateService();

        // Act  
        var dollars = rateService.GetDollarRateFromBitcoins(currency, coins);

        // Assert  
        Assert.Equal(convertedDollars, dollars.Result);
    }

}