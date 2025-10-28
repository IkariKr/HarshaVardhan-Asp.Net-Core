using Microsoft.AspNetCore.Mvc;

namespace EnvironmentsExample.Controllers;

public class HomeController(IWebHostEnvironment webHostEnvironment) : Controller
{
    //在任意地方注入IWebHostEnvironment
    private readonly IWebHostEnvironment _webHostEnvironment = webHostEnvironment; 
    
    // GET
    [Route("/")]
    public IActionResult Index()
    {
        ViewBag.CurrentEnvironment = _webHostEnvironment.EnvironmentName;
        return View();
    }
    
  
}