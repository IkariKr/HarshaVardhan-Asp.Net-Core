using Autofac;
using Autofac.Extensions.DependencyInjection;
using ServiceContracts;
using Services;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

builder.Services.AddControllersWithViews();

// builder.Services.Add(new ServiceDescriptor(
//     typeof(ICitiesService),
//     typeof(CitiesService),
//     ServiceLifetime.Scoped
// )); //每当请求ICitiesService对象，就提供一个CitiesService

builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerDependency(); // AddTransient
    containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().InstancePerLifetimeScope(); // AddScope
    containerBuilder.RegisterType<CitiesService>().As<ICitiesService>().SingleInstance(); // AddInstance
});

builder.Services.AddScoped<ICitiesService, CitiesService>();


var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();