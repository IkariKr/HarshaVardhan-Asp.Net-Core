var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddMvc();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();

app.Run();