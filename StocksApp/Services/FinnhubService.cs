using System.ComponentModel;
using System.Text.Json;
using StocksApp.ServiceContracts;

namespace StocksApp.Services;

public class FinnhubService(IHttpClientFactory clientFactory):IFinnhubService
{
    private readonly IHttpClientFactory _httpClientFactory = clientFactory;
    
    public async  Task<Dictionary<string, object>> GetStockPriceQuote(string stockSymbol)
    {
        using (HttpClient httpClient = _httpClientFactory.CreateClient())
        {
            HttpRequestMessage request = new HttpRequestMessage()
            {
                RequestUri = new Uri("https://finnhub.io/api/v1/quote?symbol=AAPL&token=d402slhr01qkrgfb3rggd402slhr01qkrgfb3rh0"),
                Method = HttpMethod.Get
            };
            
            var httpResponseMessage = await httpClient.SendAsync(request);
            var stream = await httpResponseMessage.Content.ReadAsStreamAsync();
            
            var reader = new StreamReader(stream);
            var response = await reader.ReadToEndAsync();
            
            var responseDictionary = JsonSerializer.Deserialize<Dictionary<string,object>>(response);

            if (responseDictionary == null)
                throw new InvalidOperationException("No response from finnhub service");
            
            if(responseDictionary.ContainsKey("error"))
                throw new InvalidOperationException("Error from finnhub service");
            
            return responseDictionary;
        }
        
    }
}