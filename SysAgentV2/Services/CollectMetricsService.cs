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

        public Task<CollectMetrics> CreateMetricData(CollectMetrics metric)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CollectMetrics>> GetAllMetricData()
        {
            throw new NotImplementedException();
        }

        public Task<CollectMetrics> GetMetricByDate(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task PurgeData()
        {
            throw new NotImplementedException();
        }

        public Task PurgeMetricDataBeforeDate(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
