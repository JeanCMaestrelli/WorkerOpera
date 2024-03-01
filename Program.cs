using WorkerOpera;
using Quartz;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionScopedJobFactory();
            q.AddJobAndTrigger<WorkerOperaJob>(hostContext.Configuration);            
        });

        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
    })
    .UseWindowsService()
    .Build();

await host.RunAsync();

//sc create servicowindows binPath=C:\temp\servicowindows.exe
