using SysAgentV2.Models.Scripts;
using SysAgentV2.Repository.Interfaces;
using SysAgentV2.Services.Interfaces;

namespace SysAgentV2.Services
{
    public class ScriptCmdService : IScriptCmdService
    {
        private readonly IScriptCmdRepository _repo;
        public ScriptCmdService(IScriptCmdRepository ScriptCmdRepository)
        {
            _repo = ScriptCmdRepository;
        }
        public async Task<ScriptCmd> CreateScript(ScriptCmd scripts)
        {
            var scriptModel = await _repo.GetScriptCmdByTagAsync(scripts.Tag);
            if (scriptModel != null && scriptModel.Tag == scripts.Tag)
                return null;
            await _repo.CreateScriptAsync(scripts);
            return scripts;
        }

        public async Task<bool> DeleteScript(string uuid)
        {
            return await _repo.DeleteScriptAsync(uuid);
        }

        public async Task<ScriptCmd> GetScriptCmdByUuid(string uuid)
        {
            return await _repo.GetScriptCmdByUuidAsync(uuid);
        }

        public async Task<IEnumerable<ScriptCmd>> GetAllScripts()
        {
            var listScripts = await _repo.GetAllScriptsAsync();
            return listScripts;
        }

        public async Task<ScriptCmd> UpdateAsync(ScriptCmd scripts)
        {
            return await _repo.UpdateAsync(scripts);
        }
    }
}
