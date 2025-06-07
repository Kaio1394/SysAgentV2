
using SysAgentV2.Data;
using SysAgentV2.Enum;
using SysAgentV2.Helpers.Interfaces;
using SysAgentV2.Repository.Interfaces;
using SysAgentV2.Services.Interfaces;
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
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<SysDbContext>();
                    var helper = scope.ServiceProvider.GetRequiredService<IHelper>();
                    var serviceMetrics = scope.ServiceProvider.GetRequiredService<ICollectMetricsService>();

                    var healthStatus = dbContext.AgentHealthStatus.FirstOrDefault(x => x.Id == 1);
                    if (healthStatus == null)
                    {
                        _logger.LogError($"Table[{nameof(dbContext.AgentHealthStatus)}] is empty.");
                        break;
                    }

                    var statusModel = dbContext.AgentStatus.FirstOrDefault(x => x.Id == 1);
                    if (statusModel == null)
                    {
                        _logger.LogError($"Table[{nameof(dbContext.AgentStatus)}] is empty.");
                        break;
                    }

                    _logger.LogInformation($"Checking agent status collect data: {nameof(dbContext.AgentStatus)} = {statusModel.Status}; " +
                        $"{nameof(dbContext.AgentHealthStatus)} = {healthStatus.HealthStatus}");

                    if (statusModel.Status == ExecutionStatus.RUNNING.ToString() &&
                        healthStatus.HealthStatus == HealthStatus.ACTIVE.ToString())
                    {
                        var infoHardware = await helper.GetHardwareInfoAsync();

                        var json = JsonSerializer.Serialize(infoHardware, new JsonSerializerOptions { WriteIndented = true });
                        await serviceMetrics.InsertInfoHardwareAsync(new Models.CollectMetrics
                        {
                            JsonResult = json
                        });
                        _logger.LogInformation(json);
                    }
                }

                await Task.Delay(TimeSpan.FromSeconds(1), stoppingToken);
            }
        }

    }
}
