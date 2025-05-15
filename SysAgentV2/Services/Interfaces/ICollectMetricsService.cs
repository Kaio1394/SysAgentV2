using SysAgentV2.Models;

namespace SysAgentV2.Services.Interfaces
{
    public interface ICollectMetricsService
    {
        Task<IEnumerable<CollectMetrics>> GetAllMetricData();
        Task<CollectMetrics> GetMetricByDate(DateTime date);
        Task<CollectMetrics> CreateMetricData(CollectMetrics metric);
        Task PurgeData();
        Task PurgeMetricDataBeforeDate(DateTime date);
    }
}
