using Microsoft.AspNetCore.Mvc;

namespace ViewExample.Controllers;

public class ProductsController : Controller
{
    // GET
    [Route("products/all")]
    public IActionResult Index()
    {
        return View();
    }
}