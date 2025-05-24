using Microsoft.EntityFrameworkCore;
using SysAgentV2.Data;
using SysAgentV2.Models;
using SysAgentV2.Repository.Interfaces;

namespace SysAgentV2.Repository
{
    public class AgentExecutionStatusRepository : IAgentExecutionStatusRepository
    {
        private readonly SysDbContext _context;

        public AgentExecutionStatusRepository(SysDbContext context)
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

        public Task Update(AgentExecutionStatus agent)
        {
            _context.AgentStatus.Update(agent);
            return Task.CompletedTask;
        }
    }
}
