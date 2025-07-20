using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace BitcoinConverterApp.Code;

public class CurrencyRateService : IBitcoinExchangeService
{

    private HttpClient _httpClient;


    public CurrencyRateService()
    {
        _httpClient = new HttpClient();
    }
    public CurrencyRateService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<decimal> FetchCurrencyRate(string currencyCode)
    {
        try
        {
            var url = $"https://api.coingecko.com/api/v3/simple/price?ids=bitcoin&vs_currencies={currencyCode.ToLower()}";
            var json = await _httpClient.GetStringAsync(url);
            var data = JObject.Parse(json);

            var rate = data["bitcoin"]?[currencyCode.ToLower()]?.Value<decimal>();
            if (rate == null)
            {
                throw new Exception("Currency not found in API response.");
            }

            return rate.Value;
        }
        catch (HttpRequestException httpEx)
        {
            // Handle HTTP request issues (e.g., timeout, 404)
            throw new Exception("Error while making HTTP request: " + httpEx.Message, httpEx);
        }
        catch (JsonException jsonEx)
        {
            // Handle JSON parsing errors
            throw new Exception("Error parsing JSON response: " + jsonEx.Message, jsonEx);
        }
        catch (Exception ex)
        {
            // Handle all other errors
            throw new Exception("An error occurred while fetching Bitcoin exchange rate: " + ex.Message, ex);
        }

    }

    public async Task<decimal> GetDollarRateFromBitcoins(string currencyCode, int coins)
    {
        var totalDollars = await FetchCurrencyRate(currencyCode) * coins;
        return totalDollars;
    }

}
