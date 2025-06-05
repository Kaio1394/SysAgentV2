using SysAgentV2.Models.Schedulling;

namespace SysAgentV2.Repository.Interfaces
{
    public interface IScheduleScriptsRepository
    {
        Task<ScheduleScripts> CreateScheduleScript(ScheduleScripts scheduleScripts);
        Task<IEnumerable<ScheduleScripts>> GetAllScheduleScript();
    }
}
