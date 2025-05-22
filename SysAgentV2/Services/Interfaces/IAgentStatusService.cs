using SysAgentV2.DTOs;
using SysAgentV2.Models;

namespace SysAgentV2.Services.Interfaces
{
    public interface IAgentStatusService
    {
        Task<AgentStatusDto?> GetStatusAsync();
        Task<bool> UpdateStatusAsync(AgentStatus agent);
    }
}
