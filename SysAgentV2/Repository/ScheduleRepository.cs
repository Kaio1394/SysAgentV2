using Microsoft.EntityFrameworkCore;
using SysAgentV2.Data;
using SysAgentV2.Models.Schedulling;
using SysAgentV2.Repository.Interfaces;

namespace SysAgentV2.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly ISysDbContext _context;
        public ScheduleRepository(ISysDbContext context)
        {
            _context = context;
        }
        public async Task<Schedule> CreateScheduleAsync(Schedule schedule)
        {
            await _context.Schedule.AddAsync(schedule);
            await _context.SaveChangesAsync();
            return schedule;
        }

        public async Task<bool> DeleteScheduleAsync(Schedule schedule)
        {
            _context.Schedule.Remove(schedule);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Schedule>> GetAllScheduleAsync()
        {
            return await _context.Schedule.ToListAsync();
        }

        public async Task<Schedule> GetScheduleByTagAsync(string tag)
        {
            return await _context.Schedule.FirstOrDefaultAsync(x => tag == x.TagSchedule);
        }

        public async Task<Schedule> GetScheduleByUuidAsync(string uuid)
        {
            return await _context.Schedule.FirstOrDefaultAsync(x => uuid == x.Uuid);
        }

        public Task<Schedule> UpdateScheduleAsync(Schedule schedule)
        {
            throw new NotImplementedException();
        }
    }
}
