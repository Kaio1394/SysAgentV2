namespace SysAgentV2.Services.Interfaces
{
    public interface IAgentScriptCmdService
    {
        Task<Models.AgentScriptCmd> CreateScript(Models.AgentScriptCmd scripts);
        Task<Models.AgentScriptCmd> Update(Models.AgentScriptCmd scripts);
        Task<Models.AgentScriptCmd> GetAgentScriptCmdByUuid(string uuid);

        Task<IEnumerable<Models.AgentScriptCmd>> GetAllScripts();
    }
}
