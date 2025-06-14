
namespace SysAgentV2.Worker
{
    public class ScheduleWorkder : BackgroundService
    {
        private readonly ILogger<ScheduleWorkder> _logger;
        public ScheduleWorkder(ILogger<ScheduleWorkder> logger)
        {
            _logger = logger;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
