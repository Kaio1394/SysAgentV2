using Microsoft.EntityFrameworkCore;
using SysAgentV2.Data;
using SysAgentV2.Models.Scripts;
using SysAgentV2.Repository.Interfaces;
using System;

namespace SysAgentV2.Repository
{
    public class ScriptCmdRepository : IScriptCmdRepository
    {
        private readonly SysDbContext _context;
        public ScriptCmdRepository(SysDbContext context)
        {
            _context = context;
        }

        public async Task<ScriptCmd> CreateScriptAsync(ScriptCmd scripts)
        {
            await _context.ScriptCmd.AddAsync(scripts);
            await _context.SaveChangesAsync();
            return scripts;
        }

        public async Task<bool> DeleteScriptAsync(string uuid)
        {
            var script = await _context.ScriptCmd.FirstOrDefaultAsync(e => e.Uuid == uuid);
            if (script == null)
                return false;

            _context.ScriptCmd.Remove(script);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ScriptCmd> GetScriptCmdByTagAsync(string tag)
        {
            return await _context.ScriptCmd.FirstOrDefaultAsync(s => s.Tag == tag);
        }

        public async Task<ScriptCmd> GetScriptCmdByUuidAsync(string uuid)
        {
            return await _context.ScriptCmd.FirstOrDefaultAsync(s => s.Uuid == uuid);
        }

        public async Task<IEnumerable<ScriptCmd>> GetAllScriptsAsync()
        {
            var listScripts = await _context.ScriptCmd.ToListAsync();
            return listScripts;
        }

        public async Task<bool> SaveChanges()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<ScriptCmd> UpdateAsync(ScriptCmd scripts)
        {
            var existingScript = await _context.ScriptCmd.FirstOrDefaultAsync(e => e.Uuid == scripts.Uuid);
            if(existingScript != null)
            {
                existingScript.Tag = scripts.Tag;
                existingScript.Description = scripts.Description;
                existingScript.UpdatedAt = DateTime.Now;
                await _context.SaveChangesAsync();
            }
            return scripts;
        }
    }
}
