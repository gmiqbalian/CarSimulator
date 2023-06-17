﻿using CarSimulator;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServicesLibrary.Services;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services => 
    {
        //services.AddTransient<IDrivingService, DrivingService>();
        services.AddSingleton<Application>();
    })
    .Build();

var app = host.Services.GetRequiredService<Application>();
app.Run();



