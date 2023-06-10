using CarSimulator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServicesLibrary.Services;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => 
    {
        services.AddTransient<IDrivingServices, DrivingServices>();
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



