using Microsoft.EntityFrameworkCore;
using SysAgentV2.Data;
using SysAgentV2.Models.Schedulling;
using SysAgentV2.Repository.Interfaces;

namespace SysAgentV2.Repository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private readonly SysDbContext _context;
        public ScheduleRepository(SysDbContext context)
        {
            _context = context;
        }
        public async Task<Schedule> CreateScheduleAsync(Schedule schedule)
        {
            await _context.Schedule.AddAsync(schedule);
            await _context.SaveChangesAsync();
            return schedule;
        }

        public Task<bool> DeleteScheduleAsync(string uuid)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Schedule>> GetAllScheduleAsync()
        {
            return await _context.Schedule.ToListAsync();
        }

        public Task<Schedule> GetScheduleByTagAsync(string tag)
        {
            throw new NotImplementedException();
        }

        public Task<Schedule> GetScheduleUuidAsync(string uuid)
        {
            throw new NotImplementedException();
        }

        public Task<Schedule> UpdateScheduleAsync(Schedule schedule)
        {
            throw new NotImplementedException();
        }
    }
}
