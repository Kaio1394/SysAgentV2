using Microsoft.EntityFrameworkCore;
using SysAgentV2.Data;
using SysAgentV2.Models;
using SysAgentV2.Repository.Interfaces;

namespace SysAgentV2.Repository
{
    public class AgentStatusRepository : IAgentStatusRepository
    {
        private readonly SysDbContext _context;

        public AgentStatusRepository(SysDbContext context)
        {
            _context = context;
        }
        public async Task<AgentStatus?> GetByIdAsync(int id = 1)
        {
            return await _context.AgentStatus.FindAsync(id);
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Task Update(AgentStatus agent)
        {
            _context.AgentStatus.Update(agent);
            return Task.CompletedTask;
        }
    }
}
