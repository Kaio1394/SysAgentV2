using Microsoft.CodeAnalysis.Scripting;

namespace SysAgentV2.Repository.Interfaces
{
    public interface IAgentScriptCmdRepository
    {
        Task<Models.AgentScriptCmd> CreateScriptAsync(Models.AgentScriptCmd scripts);
        Task<Models.AgentScriptCmd> UpdateAsync(Models.AgentScriptCmd scripts);
        Task<Models.AgentScriptCmd> GetAgentScriptCmdByUuidAsync(string uuid);
        Task<Models.AgentScriptCmd> GetAgentScriptCmdByTagAsync(string tag);
        Task<IEnumerable<Models.AgentScriptCmd>> GetAllScriptsAsync();
        Task<bool> DeleteScriptAsync(string uuid);
        Task<bool> SaveChanges();
    }
}
