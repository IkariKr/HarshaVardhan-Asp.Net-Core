var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //将所有Controller注入到服务中
var app = builder.Build();
app.UseStaticFiles();
app.MapControllers();//为所有控制器的所有action方法启用路由

// app.MapGet("/", () => "Hello World!");

app.Run();