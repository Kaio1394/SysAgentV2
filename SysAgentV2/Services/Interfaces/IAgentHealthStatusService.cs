using SysAgentV2.DTOs;
using SysAgentV2.Models;

namespace SysAgentV2.Services.Interfaces
{
    public interface IAgentHealthStatusService
    {
        Task<AgentExecutionStatusDto?> GetHealthStatusAsync();
        //Task<bool> UpdateHealthStatusAsync(string status);
    }
}
