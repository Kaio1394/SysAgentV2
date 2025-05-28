using Microsoft.CodeAnalysis.Scripting;
using SysAgentV2.Models.Scripts;

namespace SysAgentV2.Repository.Interfaces
{
    public interface IScriptCmdRepository
    {
        Task<ScriptCmd> CreateScriptAsync(ScriptCmd scripts);
        Task<ScriptCmd> UpdateAsync(ScriptCmd scripts);
        Task<ScriptCmd> GetScriptCmdByUuidAsync(string uuid);
        Task<ScriptCmd> GetScriptCmdByTagAsync(string tag);
        Task<IEnumerable<ScriptCmd>> GetAllScriptsAsync();
        Task<bool> DeleteScriptAsync(string uuid);
        Task<bool> SaveChanges();
    }
}
