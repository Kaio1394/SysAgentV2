using Microsoft.CodeAnalysis.Scripting;
using Microsoft.EntityFrameworkCore;
using SysAgentV2.Data;
using SysAgentV2.Enum;
using SysAgentV2.Models;
using SysAgentV2.Repository.Interfaces;

namespace SysAgentV2.Repository
{
    public class AgentExecutionStatusRepository : IAgentExecutionStatusRepository
    {
        private readonly ISysDbContext _context;

        public AgentExecutionStatusRepository(ISysDbContext context)
        {
            _context = context;
        }
        public async Task<AgentExecutionStatus?> GetByIdAsync(int id = 1)
        {
            return await _context.AgentStatus.FindAsync(id);
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateAsync(int statusInt)
        {
            var status = await _context.AgentStatus.FirstOrDefaultAsync(e => e.Id == 1);
            if (status != null)
            {
                if(statusInt == 1)
                    status.Status = ExecutionStatus.RUNNING.ToString();
                else 
                    status.Status = ExecutionStatus.STOPPED.ToString();
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
