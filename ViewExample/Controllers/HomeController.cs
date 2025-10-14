using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using ViewExample.Models;

namespace ViewExample.Controllers;

public class HomeController : Controller
{
    [Route("home")]
    [Route("/")]
    public IActionResult Index()
    {
        ViewData["pageTitle"] = "Asp.Net Core Demo App";
        List<Person> people = new List<Person>()
        {
            new Person() { PersonName = "Json", DateOfBirth = new DateTime(2000, 1, 1) },
            new Person() { PersonName = "Mike", DateOfBirth = new DateTime(1980, 1, 1) },
            new Person() { PersonName = "Mike2", DateOfBirth = new DateTime(1990, 1, 1) }, 
            new Person() { PersonName = "Mike3", DateOfBirth = new DateTime(1995, 1, 1) }, 
            new Person() { PersonName = "Mike4", DateOfBirth = new DateTime(1997, 1, 1) }
        };

        ViewData["people"] = people;

        return View("Index", people);
        return View(people); // @Model 注入到视图
        return View(); //默认搜索 Views/Home/Index.cshtml
        //return View("abc");
        return new ViewResult() { ViewName = "abc" };
    }

    [Route("person-details/{name}")]
    public IActionResult Details(string? name)
    {
        if (name is null)
            return Content("Person name can't be null");
        
        List<Person> people = new List<Person>()
        {
            new Person() { PersonName = "Json", DateOfBirth = new DateTime(2000, 1, 1) },
            new Person() { PersonName = "Mike", DateOfBirth = new DateTime(1980, 1, 1) },
            new Person() { PersonName = "Mike2", DateOfBirth = new DateTime(1990, 1, 1) }, 
            new Person() { PersonName = "Mike3", DateOfBirth = new DateTime(1995, 1, 1) }, 
            new Person() { PersonName = "Mike4", DateOfBirth = new DateTime(1997, 1, 1) }
        };

        Person? matchingPerson = people.FirstOrDefault(p => p.PersonName == name);

        return View(matchingPerson);
    }

    [Route("person-with-product")]
    public IActionResult PersonAndProduct() //如果控制器与View同名，则默认搜索Views/Home/PersonAndProduct.cshtml
                                            //返回View的时候不需要传视图名称
    {
        Person person = new Person() { PersonName = "Json" };
        Product product = new Product() { ProductName = "Dotnet" };
        PersonAndProductWarpperModel model = new PersonAndProductWarpperModel();
        model.PersonData = person;
        model.ProductData = product;
        return View(model);
    }
}