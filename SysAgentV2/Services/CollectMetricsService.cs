using SysAgentV2.Models;
using SysAgentV2.Repository.Interfaces;
using SysAgentV2.Services.Interfaces;

namespace SysAgentV2.Services
{
    public class CollectMetricsService: ICollectMetricsService
    {
        private readonly ICollectMetricsRepository _repository;

        public CollectMetricsService(ICollectMetricsRepository repository)
        {
            _repository = repository;
        }

        public Task<bool> InsertInfoHardwareAsync(CollectMetrics metric)
        {
            return _repository.InsertInfoHardwareAsync(metric);
        }

        public async Task<IEnumerable<CollectMetrics>> GetAllMetricDataAsync()
        {
            return await _repository.GetAllMetricDataAsync();
        }
    }
}
