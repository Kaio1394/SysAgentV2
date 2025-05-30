﻿using SysAgentV2.DTOs;
using SysAgentV2.Models;

namespace SysAgentV2.Services.Interfaces
{
    public interface IAgentHealthStatusService
    {
        Task<AgentHealthStatus?> GetHealthStatusAsync();
        Task<bool> ActivateAgentAsync();
        Task<bool> DisableAgentAsync();
    }
}
