using Microsoft.AspNetCore.Mvc;
using ServiceContracts;
using Services;

namespace DIExample.Controllers;

public class HomeController : Controller
{
    private readonly ICitiesService _citiesService;
    
    private readonly ICitiesService _citiesService1;
    private readonly ICitiesService _citiesService2;
    private readonly ICitiesService _citiesService3;
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public HomeController(ICitiesService citiesService,ICitiesService citiesService1, 
        ICitiesService citiesService2, ICitiesService citiesService3
        , IServiceScopeFactory serviceScopeFactory)
    {
        _citiesService = citiesService;
        _citiesService1 = citiesService1;
        _citiesService2 = citiesService2;
        _citiesService3 = citiesService3;
        _serviceScopeFactory = serviceScopeFactory;
    }
    
    // GET
    [Route("/")]
    public IActionResult Index([FromServices] ICitiesService citiesService)
    {
        var cities = citiesService.GetCities();

        //创建子作用域
        using (var scope = _serviceScopeFactory.CreateScope())
        {
            //Inject CitiesService

            var scopeCitiesService = scope.ServiceProvider.GetRequiredService<ICitiesService>();

            ViewBag.InstanceScopeCitiesServiceId = scopeCitiesService.ServiceInstanceId;
            
            //end of scrope;it call CitiesService.Dispose();
        }
        
        return View(cities);
    }
}