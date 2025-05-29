using SysAgentV2.Models;
using SysAgentV2.Models.Scripts;

namespace SysAgentV2.Repository.Interfaces
{
    public interface ICollectMetricsRepository
    {
        Task<IEnumerable<CollectMetrics>> GetAllMetricDataAsync();
        Task<CollectMetrics> GetMetricByDateAsync(DateTime date);
        Task<CollectMetrics> InsertInfoHardwareAsync(CollectMetrics metric);
        Task PurgeDataAsync();
        Task PurgeMetricDataBeforeDateAsync(DateTime date);
    }
}
