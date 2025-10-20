using Microsoft.AspNetCore.Mvc;

namespace LayoutViewsExample.Controllers;

public class HomeController : Controller
{
    // GET
    [Route("/")]
    public IActionResult Index()
    {
        return View();
    }
    
    [Route("about-company")]
    public IActionResult About()
    {
        return View();
    }
    
    [Route("contact-support")]
    public IActionResult Contact()
    {
        return View();
    }
}