using Microsoft.EntityFrameworkCore;
using SysAgentV2.Data;
using SysAgentV2.Models;
using SysAgentV2.Repository.Interfaces;
using System;

namespace SysAgentV2.Repository
{
    public class AgentScriptCmdRepository : IAgentScriptCmdRepository
    {
        private readonly SysDbContext _context;
        public AgentScriptCmdRepository(SysDbContext context)
        {
            _context = context;
        }

        public async Task<Models.AgentScriptCmd> CreateScriptAsync(AgentScriptCmd scripts)
        {
            await _context.AgentScriptCmd.AddAsync(scripts);
            await _context.SaveChangesAsync();
            return scripts;
        }

        public async Task<bool> DeleteScriptAsync(string uuid)
        {
            var script = await _context.AgentScriptCmd.FirstOrDefaultAsync(e => e.Uuid == uuid);
            if (script == null)
                return false;

            _context.AgentScriptCmd.Remove(script);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<AgentScriptCmd> GetAgentScriptCmdByTagAsync(string tag)
        {
            return await _context.AgentScriptCmd.FirstOrDefaultAsync(s => s.Tag == tag);
        }

        public async Task<AgentScriptCmd> GetAgentScriptCmdByUuidAsync(string uuid)
        {
            return await _context.AgentScriptCmd.FirstOrDefaultAsync(s => s.Uuid == uuid);
        }

        public async Task<IEnumerable<AgentScriptCmd>> GetAllScriptsAsync()
        {
            var listScripts = await _context.AgentScriptCmd.ToListAsync();
            return listScripts;
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Models.AgentScriptCmd> UpdateAsync(AgentScriptCmd scripts)
        {
            var existingScript = await _context.AgentScriptCmd.FirstOrDefaultAsync(e => e.Uuid == scripts.Uuid);
            if(existingScript != null)
            {
                existingScript.Tag = scripts.Tag;
                existingScript.IsChained = scripts.IsChained;
                existingScript.Description = scripts.Description;
                existingScript.UpdatedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return scripts;
        }
    }
}
