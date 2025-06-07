using SysAgentV2.Models;
using SysAgentV2.Models.Scripts;

namespace SysAgentV2.Repository.Interfaces
{
    public interface ICollectMetricsRepository
    {
        Task<bool> InsertInfoHardwareAsync(CollectMetrics metric);
        Task<IEnumerable<CollectMetrics>> GetAllMetricDataAsync();
    }
}
