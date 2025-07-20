using Xunit;
using BitcoinConverterApp.Code;
using Moq;
using Moq.Protected;
using System.Net;


namespace BitcoinConverterApp.Tests;

public class CurrencyRateServiceTests
{

    private const string MOCK_COINGECKO_USD_RESPONSE = "{\"bitcoin\":{\"usd\":118008}}";
    private CurrencyRateService mockCurrencyRateService;

    public CurrencyRateServiceTests()
    {
        mockCurrencyRateService = GetMockCurrencyRateService();
    }


    private CurrencyRateService GetMockCurrencyRateService()
    {
        var mockHandler = new Mock<HttpMessageHandler>();
        mockHandler.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync((HttpRequestMessage request, CancellationToken token) =>
            {
                var uri = request.RequestUri.ToString();

                // Extract currency from query string
                var currency = "usd"; // default fallback
                if (uri.Contains("vs_currencies="))
                {
                    currency = uri.Split("vs_currencies=")[1].Split("&")[0].ToLower();
                }
                // Fake price mapping
                var fakePrices = new Dictionary<string, decimal>
                {
                { "usd", 118008 },
                { "inr", 86 },
                { "eur", 109000 },
                { "jpy", 16000000 },
                { "gbp", 94000 }
                };

                var price = fakePrices.ContainsKey(currency) ? fakePrices[currency] : 0;
                var jsonResponse = $"{{\"bitcoin\":{{\"{currency}\":{price}}}}}";
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent(jsonResponse)
                };
            });

        var httpClient = new HttpClient(mockHandler.Object);
        return new CurrencyRateService(httpClient);
    }

    [Fact]
    public async void FetchRate_USD_ReturnsExpectedRate()
    {
        //act 
        var acutalRate = await mockCurrencyRateService.FetchCurrencyRate("USD");

        //assert
        var expectedRate = 118008;

        Assert.Equal(expectedRate, acutalRate);
    }

    [Fact]
    public async void FetchRate_INR_ReturnsExpectedRate()
    {
        //act 
        var acutalRate = await mockCurrencyRateService.FetchCurrencyRate("INR");

        //assert
        var expectedRate = 86;

        Assert.Equal(expectedRate, acutalRate);

    }

    [Theory] //[Theory] allows you to parameterize your tests and reuse the same logic for different inputs. 
    [InlineData("USD", 1, 118008)]
    [InlineData("USD", 2, 236016)]
    [InlineData("INR", 1, 86)]
    [InlineData("INR", 2, 172)]
    public async void ConvertBitcoins_BitcoinsToCurrency_ReturnsCurrency(string currency, int coins, int convertedDollars)
    {
        // Act  
        var dollars = await mockCurrencyRateService.GetDollarRateFromBitcoins(currency, coins);

        // Assert  
        Assert.Equal(convertedDollars, dollars);
    }

}