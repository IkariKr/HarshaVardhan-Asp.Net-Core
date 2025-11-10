using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using StocksApp.Models;
using StocksApp.Services;

namespace StocksApp.Controllers;

public class HomeController(FinnhubService finnhubService,IOptions<TradingOptions> tradingOptions) : Controller
{
    private readonly FinnhubService _finnhubService = finnhubService;
    private readonly IOptions<TradingOptions> _tradingOptions = tradingOptions;


    // GET
    [Route("/")]
    public async Task<IActionResult> Index()
    {
        if(_tradingOptions.Value.DefaultStockSymbol == null)
            _tradingOptions.Value.DefaultStockSymbol = "AAPL";
        
        var responseDictionary = await _finnhubService.GetStockPriceQuote(tradingOptions.Value.DefaultStockSymbol);

        Stock stock = new()
        {
            StockSymbol = tradingOptions.Value.DefaultStockSymbol,
            CurrentPrice = Convert.ToDouble(responseDictionary["c"]!.ToString()),
            LowestPrice = Convert.ToDouble(responseDictionary["l"]!.ToString()),
            HighestPrice = Convert.ToDouble(responseDictionary["h"]!.ToString()),
            OpenPrice = Convert.ToDouble(responseDictionary["o"]!.ToString()),
        };
        return View(stock);
    }
}