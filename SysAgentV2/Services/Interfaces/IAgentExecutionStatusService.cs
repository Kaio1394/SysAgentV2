using SysAgentV2.DTOs;
using SysAgentV2.Models;

namespace SysAgentV2.Services.Interfaces
{
    public interface IAgentExecutionStatusService
    {
        Task<AgentExecutionStatusDto?> GetStatusAsync();
        Task<bool> UpdateStatusAsync(string status);
    }
}
