
using SysAgentV2.Data;
using SysAgentV2.Enum;
using SysAgentV2.Helpers.Interfaces;
using System.Text.Json;

namespace SysAgentV2.Worker
{
    public class StatusCollectDataWorker: BackgroundService 
    {
        private readonly ILogger<StatusCollectDataWorker> _logger;
        private readonly IServiceScopeFactory _scopeFactory;

        public StatusCollectDataWorker(ILogger<StatusCollectDataWorker> logger, IServiceScopeFactory scopeFactory)
        {
            _logger = logger;
            _scopeFactory = scopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<SysDbContext>();
                var helper = scope.ServiceProvider.GetRequiredService<IHelper>();

                while (!stoppingToken.IsCancellationRequested)
                {
                    var statusModel = dbContext.AgentStatus.FirstOrDefault(x => x.Id == 1);
                    if(statusModel == null)
                    {
                        _logger.LogError($"Table[{nameof(dbContext.AgentStatus)}] is empty.");
                        break;
                    }
                    _logger.LogInformation($"Checking agent status collect data: {statusModel.Status}");

                    var status = statusModel.Status;
                    if (status == ExecutionStatus.RUNNING.ToString())
                    {
                        var infoHardware = await helper.GetHardwareInfoAsync();
                        var json = JsonSerializer.Serialize(infoHardware, new JsonSerializerOptions { WriteIndented = true });
                        _logger.LogInformation(json);
                    }
                    await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
                }
            }
        }
    }
}
