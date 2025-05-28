using SysAgentV2.Models.Scripts;

namespace SysAgentV2.Services.Interfaces
{
    public interface IScriptCmdService
    {
        Task<ScriptCmd> CreateScript(ScriptCmd scripts);
        Task<ScriptCmd> UpdateAsync(ScriptCmd scripts);
        Task<ScriptCmd> GetScriptCmdByUuid(string uuid);
        Task<bool> DeleteScript(string uuid);

        Task<IEnumerable<ScriptCmd>> GetAllScripts();
    }
}
