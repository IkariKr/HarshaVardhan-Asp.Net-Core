using Microsoft.AspNetCore.Mvc;

namespace PartialViewsExample.Controllers;

public class HomeController : Controller
{
    // GET
    [Route("/")]
    public IActionResult Index()
    {
        ViewBag.ListItems = new List<string>() {"Delhi", "Mumbai", "Chennai"};
        ViewData["ListTitle"] = "Cities";
        
        return View();
    }
    
    [Route("about")]
    public IActionResult About()
    {
        return View();
    }
}