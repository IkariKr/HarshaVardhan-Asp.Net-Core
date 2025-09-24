using ControllersExample.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControllersExample.Controllers;

[Controller] //添加Controller 特性或以Controller作为类名后缀时，
             //AddControllers和MapControllers 将自动应用这个控制器
public class HomeController :Controller // 继承Controller后可以用Content作为返回值
{
    [Route("home")]
    [Route("/")]
    public IActionResult Index()
    {
        // return Content(content: "Hello Form Index",
        //     contentType: "text/plain");
        return Content(content: "<h1>Welcome</h1><h2>Hello from Index</h2>",
            contentType: "text/html");
    }

    [Route("person")]
    public IActionResult Person()
    {
        // return Json(new { name = 123, age = 12 });
        return Json(new Person()
        {
            Id = Guid.NewGuid(),
            Age = 12,
            FirstName = "James",
            LastName = "Smith",
        });
    }

    //文件下载-文件夹存在在wwwroot文件夹之内（StaticFiles文件）
    //一个小坑：virtualPath不能包含 . , 
    [Route("file-download")]
    public IActionResult FileDownload()
    {
        //return new VirtualFileResult("/dotnet多线程.pdf","application/pdf");
        return File("/dotnet多线程.pdf","application/pdf");
    }
    
    //文件下载-文件夹存在在wwwroot文件夹之外
    [Route("file-download2")]
    public IActionResult FileDownload2()
    {
        //return new PhysicalFileResult(@"H:\OneDrive\Develop\Cshape\Study\HarshaVardhan-Asp.Net Core\ControllersExample\wwwroot\dotnet多线程.pdf","application/pdf");
        return PhysicalFile(@"H:\OneDrive\Develop\Cshape\Study\HarshaVardhan-Asp.Net Core\ControllersExample\wwwroot\dotnet多线程.pdf","application/pdf");
    }
    
    //文件下载-返回字节数组
    [Route("file-download3")]
    public IActionResult FileDownload3()
    {
        var bytes = System.IO.File.ReadAllBytes(@"H:\OneDrive\Develop\Cshape\Study\HarshaVardhan-Asp.Net Core\ControllersExample\wwwroot\dotnet多线程.pdf");
        //return new FileContentResult(bytes,"application/pdf");
        return File(bytes,"application/pdf");
    }
    
    
}