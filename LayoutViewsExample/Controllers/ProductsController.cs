using Microsoft.AspNetCore.Mvc;

namespace LayoutViewsExample.Controllers;

public class ProductsController : Controller
{
    // GET
    [Route("products")]
    public IActionResult Index()
    {
        return View();
    }
    
    // GET
    [Route("search-products/{productID?}")]
    public IActionResult Search(int? productID)
    {
        ViewBag.productID = productID;
        return View();
    }
    
    // GET
    [Route("order-products")]
    public IActionResult Order()
    {
        return View();
    }
}