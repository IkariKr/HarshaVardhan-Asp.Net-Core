using Microsoft.AspNetCore.Mvc;
using ModelValidationsExample.CustomModelBinders;
using ModelValidationsExample.Models;

namespace ModelValidationsExample.Controllers;

public class HomeController : Controller
{
    // GET
    [Route("register")]
    //Bind 只有指定的属性值被接受
    //[Bind(nameof(Person.PersonName),nameof(Person.Email),nameof(Person.Password), nameof(Person.ConfirmPassword))]
    //[ModelBinder(binderType:typeof(PersonModelBinder))]  使用自定义模型绑定
    public IActionResult Index([FromForm]Person person,[FromHeader(Name = "User-Agent")] string userAgent) 
    
    //NotBind 
    {
        //可以使用此段代码验证所有模型
        if (!ModelState.IsValid)
        {
            var errorList = ModelState.Values
                .SelectMany(value => value.Errors).Select(error => error.ErrorMessage).ToList();
            var errors = string.Join("\n",errorList);
            return BadRequest(errors);
        }
        
        Console.WriteLine(userAgent);
        
        
        return Content($"{person}");
    }
}
