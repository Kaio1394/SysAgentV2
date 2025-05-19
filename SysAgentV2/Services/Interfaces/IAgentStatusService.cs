using SysAgentV2.Models;

namespace SysAgentV2.Services.Interfaces
{
    public interface IAgentStatusService
    {
        Task<AgentStatus?> GetStatusAsync();
        Task<bool> UpdateStatusAsync(AgentStatus agent);
    }
}
