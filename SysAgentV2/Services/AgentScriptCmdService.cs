using SysAgentV2.Models;
using SysAgentV2.Repository.Interfaces;
using SysAgentV2.Services.Interfaces;

namespace SysAgentV2.Services
{
    public class AgentScriptCmdService : IAgentScriptCmdService
    {
        private readonly IAgentScriptCmdRepository _repo;
        public AgentScriptCmdService(IAgentScriptCmdRepository agentScriptCmdRepository)
        {
            _repo = agentScriptCmdRepository;
        }
        public async Task<AgentScriptCmd> CreateScript(AgentScriptCmd scripts)
        {
            var scriptModel = await _repo.GetAgentScriptCmdByTagAsync(scripts.Tag);
            if (scriptModel != null && scriptModel.Tag == scripts.Tag)
                return null;
            await _repo.CreateScriptAsync(scripts);
            return scripts;
        }

        public async Task<bool> DeleteScript(string uuid)
        {
            return await _repo.DeleteScriptAsync(uuid);
        }

        public async Task<AgentScriptCmd> GetAgentScriptCmdByUuid(string uuid)
        {
            return await _repo.GetAgentScriptCmdByUuidAsync(uuid);
        }

        public async Task<IEnumerable<AgentScriptCmd>> GetAllScripts()
        {
            var listScripts = await _repo.GetAllScriptsAsync();
            return listScripts;
        }

        public async Task<AgentScriptCmd> UpdateAsync(AgentScriptCmd scripts)
        {
            return await _repo.UpdateAsync(scripts);
        }
    }
}
