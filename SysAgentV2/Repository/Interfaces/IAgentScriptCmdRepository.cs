using Microsoft.CodeAnalysis.Scripting;

namespace SysAgentV2.Repository.Interfaces
{
    public interface IAgentScriptCmdRepository
    {
        Task<Models.AgentScriptCmd> CreateScript(Models.AgentScriptCmd scripts);
        Task<Models.AgentScriptCmd> Update(Models.AgentScriptCmd scripts);
        Task<Models.AgentScriptCmd> GetAgentScriptCmdByUuid(string uuid);
        Task<IEnumerable<Models.AgentScriptCmd>> GetAllScripts();
        Task<bool> SaveChanges();
    }
}
