using Microsoft.EntityFrameworkCore;
using SysAgentV2.Data;
using SysAgentV2.Models;
using SysAgentV2.Repository.Interfaces;

namespace SysAgentV2.Repository
{
    public class CollectMetricsRepository : ICollectMetricsRepository
    {
        private readonly ISysDbContext _dbContext;

        public CollectMetricsRepository(ISysDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IEnumerable<CollectMetrics>> GetAllMetricDataAsync()
        {
            return await _dbContext.CollectMetrics.ToListAsync();
        }

        public async Task<bool> InsertInfoHardwareAsync(CollectMetrics metric)
        {
            await _dbContext.CollectMetrics.AddAsync(metric);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
