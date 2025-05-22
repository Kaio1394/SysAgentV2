using SysAgentV2.DTOs;
using SysAgentV2.Models;

namespace SysAgentV2.Services.Interfaces
{
    public interface IAgentStatusService
    {
        Task<AgentDto?> GetStatusAsync();
        Task<bool> UpdateStatusAsync(string status);
    }
}
