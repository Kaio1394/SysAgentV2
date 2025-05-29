using SysAgentV2.Models;

namespace SysAgentV2.Services.Interfaces
{
    public interface ICollectMetricsService
    {
        Task<IEnumerable<CollectMetrics>> GetAllMetricDataAsync();
        Task<CollectMetrics> GetMetricByDateAsync(DateTime date);
        Task<CollectMetrics> InsertInfoHardwareAsync(CollectMetrics metric);
        Task PurgeDataAsync();
        Task PurgeMetricDataBeforeDateAsync(DateTime date);
    }
}
