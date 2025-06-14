using SysAgentV2.Data;
using SysAgentV2.Models;
using SysAgentV2.Repository.Interfaces;

namespace SysAgentV2.Repository
{
    public class AgentHealthStatusRepository : IAgentHealthStatusRepository
    {
        private readonly ISysDbContext _dbContext;

        public AgentHealthStatusRepository(ISysDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<bool> ActivateAgentAsync()
        {
            var healthStatus = await _dbContext.AgentHealthStatus.FindAsync(1);
            if (healthStatus == null)
                return false;
            healthStatus.HealthStatus = Enum.HealthStatus.ACTIVE.ToString();
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DisableAgentAsync()
        {
            var healthStatus = await _dbContext.AgentHealthStatus.FindAsync(1);
            if (healthStatus == null)
                return false;
            healthStatus.HealthStatus = Enum.HealthStatus.DISABLED.ToString();
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<AgentHealthStatus?> GetHealthStatusAsync()
        {
            var healthStatus = await _dbContext.AgentHealthStatus.FindAsync(1);
            return healthStatus;
        }
    }
}
