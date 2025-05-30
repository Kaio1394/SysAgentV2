using SysAgentV2.DTOs;
using SysAgentV2.Models;

namespace SysAgentV2.Repository.Interfaces
{
    public interface IAgentHealthStatusRepository
    {
        Task<AgentHealthStatus?> GetHealthStatusAsync();
        Task<bool> ActivateAgentAsync();
        Task<bool> DisableAgentAsync();
    }
}
