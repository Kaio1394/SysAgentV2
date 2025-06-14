using Microsoft.EntityFrameworkCore;
using SysAgentV2.Data;
using SysAgentV2.Models.Schedulling;
using SysAgentV2.Repository.Interfaces;

namespace SysAgentV2.Repository
{
    public class ScheduleScriptsRepository: IScheduleScriptsRepository
    {
        private readonly ISysDbContext _dbContext;
        public ScheduleScriptsRepository(ISysDbContext dbContext)
        {
            _dbContext = dbContext;            
        }

        public async Task<ScheduleScripts> CreateScheduleScript(ScheduleScripts scheduleScripts)
        {
            await _dbContext.ScheduleScripts.AddAsync(scheduleScripts);
            await _dbContext.SaveChangesAsync();
            return scheduleScripts;
        }

        public async Task<IEnumerable<ScheduleScripts>> GetAllScheduleScript()
        {
            return await _dbContext.ScheduleScripts.ToListAsync();  
        }
    }
}
