using akbank_bootcamp.Logs;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MonitoringService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        Logger TxtOperation = new Logger();
        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                TxtOperation.createLog("Servis çalıştı");
                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}