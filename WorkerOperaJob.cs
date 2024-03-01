using Quartz;

namespace WorkerOpera
{
    [DisallowConcurrentExecution]
    public class WorkerOperaJob : IJob    
    {
        private readonly ILogger<WorkerOperaJob> _logger;
        public WorkerOperaJob(ILogger<WorkerOperaJob> logger)
        {
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Rodando: {time}", DateTimeOffset.Now);

            File.AppendAllText("c:\\temp\\log.txt", Environment.NewLine + $"Rodando: {DateTime.Now}");

            return Task.CompletedTask;
        }
    }
}
