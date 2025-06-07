using SysAgentV2.Models;

namespace SysAgentV2.Services.Interfaces
{
    public interface ICollectMetricsService
    {
        Task<bool> InsertInfoHardwareAsync(CollectMetrics metric);
        Task<IEnumerable<CollectMetrics>> GetAllMetricDataAsync();
        //Task<CollectMetrics> GetMetricByDateAsync(DateTime date);
        //Task PurgeDataAsync();
        //Task PurgeMetricDataBeforeDateAsync(DateTime date);
    }
}
