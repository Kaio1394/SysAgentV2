using Microsoft.EntityFrameworkCore;
using SysAgentV2.Data;
using SysAgentV2.Models;
using SysAgentV2.Repository.Interfaces;

namespace SysAgentV2.Repository
{
    public class AgentScriptCmdRepository : IAgentScriptCmdRepository
    {
        private readonly SysDbContext _context;
        public AgentScriptCmdRepository(SysDbContext context)
        {
            _context = context;
        }

        public async Task<Models.AgentScriptCmd> CreateScript(AgentScriptCmd scripts)
        {
            await _context.AgentScriptCmd.AddAsync(scripts);
            await _context.SaveChangesAsync();
            return scripts;
        }

        public async Task<AgentScriptCmd> GetAgentScriptCmdByUuid(string uuid)
        {
            return await _context.AgentScriptCmd.FirstOrDefaultAsync(s => s.Uuid == uuid);
        }

        public async Task<IEnumerable<AgentScriptCmd>> GetAllScripts()
        {
            var listScripts = await _context.AgentScriptCmd.ToListAsync();
            return listScripts;
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Models.AgentScriptCmd> Update(AgentScriptCmd scripts)
        {
            _context.AgentScriptCmd.Update(scripts);
            return scripts;
        }
    }
}
