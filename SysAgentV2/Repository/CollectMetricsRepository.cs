using SysAgentV2.Models;
using SysAgentV2.Repository.Interfaces;

namespace SysAgentV2.Repository
{
    public class CollectMetricsRepository : ICollectMetricsRepository
    {
        public Task<IEnumerable<CollectMetrics>> GetAllMetricDataAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CollectMetrics> GetMetricByDateAsync(DateTime date)
        {
            throw new NotImplementedException();
        }

        public Task<CollectMetrics> InsertInfoHardwareAsync(CollectMetrics metric)
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
