using SysAgentV2.Models.Schedulling;

namespace SysAgentV2.Services.Interfaces
{
    public interface IScheduleService
    {
        Task<Schedule> CreateScheduleAsync(Schedule schedule);
        Task<IEnumerable<Schedule>> GetAllScheduleAsync();
    }
}
