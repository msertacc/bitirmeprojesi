using Service.Worker;

IHost host = Host.CreateDefaultBuilder(args)
   .UseWindowsService(options =>
        {
            options.ServiceName = ".NET Joke Service";
        })
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
