using ModelValidationsExample.CustomModelBinders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers(options =>
{
    //options.ModelBinderProviders.Insert(0,new PersonBinderProvider()); // 将自定义模型绑定添加到控制器
});
builder.Services.AddControllers().AddXmlDataContractSerializerFormatters(); // 添加XML解析器

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();


app.MapGet("/", () => "Hello World!");

app.Run();