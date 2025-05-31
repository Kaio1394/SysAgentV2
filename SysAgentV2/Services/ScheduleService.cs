using SysAgentV2.Models.Schedulling;
using SysAgentV2.Repository.Interfaces;
using SysAgentV2.Services.Interfaces;

namespace SysAgentV2.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;
        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }
        public async Task<Schedule> CreateScheduleAsync(Schedule schedule)
        {
            return await _scheduleRepository.CreateScheduleAsync(schedule);
        }

        public async Task<bool> DeleteScheduleByUuidAsync(string uuid)
        {
            var schedule = await _scheduleRepository.GetScheduleByUuidAsync(uuid);
            if (schedule == null)
                return false;
            return await _scheduleRepository.DeleteScheduleAsync(schedule);
        }

        public async Task<IEnumerable<Schedule>> GetAllScheduleAsync()
        {
            return await _scheduleRepository.GetAllScheduleAsync();
        }

        public async Task<Schedule> GetScheduleByTagAsync(string tag)
        {
            return await _scheduleRepository.GetScheduleByTagAsync(tag);
        }

        public async Task<Schedule> GetScheduleByUuidAsync(string uuid)
        {
            return await _scheduleRepository.GetScheduleByUuidAsync(uuid);
        }
    }
}
