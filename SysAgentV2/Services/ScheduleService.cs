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

        public async Task<IEnumerable<Schedule>> GetAllScheduleAsync()
        {
            return await _scheduleRepository.GetAllScheduleAsync();
        }
    }
}
