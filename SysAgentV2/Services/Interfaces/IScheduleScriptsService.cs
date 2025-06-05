using SysAgentV2.DTOs;
using SysAgentV2.Models.Schedulling;

namespace SysAgentV2.Services.Interfaces
{
    public interface IScheduleScriptsService
    {
        Task<ScheduleScripts> CreateScheduleScriptAsync(ScheduleScriptsDto scheduleScriptsDto);
        Task<IEnumerable<ScheduleScriptsDto>> GetAllScheduleScriptAsync();
    }
}
