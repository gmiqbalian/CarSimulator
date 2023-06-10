using CarSimulator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

IHost host = Host.CreateDefaultBuilder()
    .ConfigureServices(services => {
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



