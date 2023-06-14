using CarSimulator;
using CarSimulator.Controller;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServicesLibrary.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => 
    {
        services.AddTransient<IDrivingServices, DrivingServices>();
        services.AddTransient<IDriverServices, DriverServices>();
        services.AddTransient<ICarServices, CarServices>();
        services.AddTransient<IAppController, AppController>();
        services.AddTransient<IDirectionServices, DirectionServices>();
        services.AddSingleton<Application>();
    })
    .Build();

//using (var scope = host.Services.CreateScope())
//{
//    scope.ServiceProvider.GetService<Application>().Run();
//}

//host.Run();


var app = host.Services.GetRequiredService<Application>();
app.Run();



