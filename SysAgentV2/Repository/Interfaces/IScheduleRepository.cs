using SysAgentV2.Models.Schedulling;
using SysAgentV2.Models.Scripts;

namespace SysAgentV2.Repository.Interfaces
{
    public interface IScheduleRepository
    {
        Task<Schedule> CreateScheduleAsync(Schedule schedule);
        Task<Schedule> UpdateScheduleAsync(Schedule schedule);
        Task<Schedule> GetScheduleUuidAsync(string uuid);
        Task<Schedule> GetScheduleByTagAsync(string tag);
        Task<IEnumerable<Schedule>> GetAllScheduleAsync();
        Task<bool> DeleteScheduleAsync(string uuid);
    }
}
