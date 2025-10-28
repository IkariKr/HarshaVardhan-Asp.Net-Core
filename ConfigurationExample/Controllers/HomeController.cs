using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationExample.Controllers;

public class HomeController(IConfiguration configuration,IOptions<WeatherApiOptions> weatherApiOptions) : Controller
{
    private readonly IConfiguration _configuration = configuration;
    private readonly WeatherApiOptions _weatherApiOptions = weatherApiOptions.Value;
    
    // GET
    [Route("/")]
    public IActionResult Index()
    {
        ViewBag.MyKey = _configuration["weatherapi:ClientID"];
        ViewBag.MyKey = _configuration.GetValue<string>("weatherapi:ClientID");
        IConfigurationSection wetherapiSection = _configuration.GetSection("weatherapi");
        ViewBag.MyKey = wetherapiSection["ClientID"];
        
        //Bind:Loads Configuration Value Into Existing Options Object
        var weatherApiOptions = new WeatherApiOptions();
        _configuration.Bind("weatherapi", weatherApiOptions);
        weatherApiOptions = wetherapiSection.Get<WeatherApiOptions>();

        var clientId = _weatherApiOptions.ClientID;
        var clientSecret = _weatherApiOptions.ClientSecret;
        
        
        return View();
    }
}