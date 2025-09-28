using System.Runtime.CompilerServices;
using IActionResultExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers;

public class HomeController : Controller
{
    [Route("bookstore/{bookId?}/{isloggedin?}")] //模型绑定中，路由参数比查询字符串具有更高优先级
    // GET
    public IActionResult Index([FromRoute]int? bookid,[FromQuery]bool? isloggedin,[FromQuery] Book book) // 模型绑定,大小写敏感
    {
        //检查是否提供Book id 
        // if (!Request.Query.ContainsKey("bookid"))
        //     //return Content("Book id is not supplied");
        //     return BadRequest("Book id is not supplied");
        if (!bookid.HasValue)
        {
            return BadRequest("Book id is not supplied");
        }
        
        
        //检查Book id是否为空
        if (string.IsNullOrEmpty(Request.Query["bookid"]))
        {
            //return Content("Book id can't be null or empty");
            return BadRequest("Book id can't be null or empty");
        }
        
        //检查Book id范围
        // var bookId = Convert.ToInt16( Request.Query["bookid"]);
        if (bookid < 1 || bookid > 1000)
            //return Content("Book id can't be less than 1 or greater 1000");
            return NotFound("Book id can't be less than 1 or greater 1000");
        
        //检查用户是否登录
        if (!Convert.ToBoolean(Request.Query["isloggedin"]))
        {
            //Response.StatusCode = 401;
            //return Content("User is not logged in");
            return Unauthorized("User is not logged in");
        }
        
        //return File("/dotnet多线程.pdf", "application/pdf");
        // first - parameter - 函数名称
        // second - parameter - 类名去掉controller
        // third - parameter - routeValue - 可为空对象
        
        // return new RedirectToActionResult("Books", "Store", new {}); // 302 - 临时移动
        //return RedirectToAction("Books", "Store", new {id =bookId});
        //return new LocalRedirectResult($"store/books/{bookId}"); // 302 - localUrl
        //return LocalRedirect($"store/books/{bookId}");
        //return Redirect($"store/books/{bookId}"); // 302 允许重定向到任何 URL（本地或外部）
        
        // return new RedirectToActionResult("Books", "Store", new {} , true); // 301 - 永久移动
        //return new LocalRedirectResult($"store/books/{bookId}",true); // 301 - localUrl
        //return RedirectToActionPermanent("Books", "Store", new {id =bookId});
        return RedirectPermanent($"store/books/{bookid}"); // 301 允许重定向到任何 URL（本地或外部）

    }
}