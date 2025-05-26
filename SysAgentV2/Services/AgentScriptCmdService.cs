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
            await _repo.CreateScript(scripts);
            return scripts;
        }

        public async Task<AgentScriptCmd> GetAgentScriptCmdByUuid(string uuid)
        {
            return await _repo.GetAgentScriptCmdByUuid(uuid);
        }

        public async Task<IEnumerable<AgentScriptCmd>> GetAllScripts()
        {
            var listScripts = await _repo.GetAllScripts();
            return listScripts;
        }

        public Task<AgentScriptCmd> Update(AgentScriptCmd scripts)
        {
            throw new NotImplementedException();
        }
    }
}
