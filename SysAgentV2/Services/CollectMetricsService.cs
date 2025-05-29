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

        public Task<CollectMetrics> InsertInfoHardwareAsync(CollectMetrics metric)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CollectMetrics>> GetAllMetricDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CollectMetrics> GetMetricByDateAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task PurgeDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task PurgeMetricDataBeforeDateAsync(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
