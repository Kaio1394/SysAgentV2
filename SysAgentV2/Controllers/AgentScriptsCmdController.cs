using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SysAgentV2.Models;
using SysAgentV2.Services.Interfaces;

namespace SysAgentV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgentScriptsCmdController : Controller
    {
        private readonly IAgentScriptCmdService _agentScriptCmdService;
        public AgentScriptsCmdController(IAgentScriptCmdService agentScriptCmdService) 
        {
            _agentScriptCmdService = agentScriptCmdService;
        }

        [HttpPost("create/script")]
        public async Task<IActionResult> CreateScriptCmd([FromBody] AgentScriptCmd agentScript)
        {
            var agent = await _agentScriptCmdService.CreateScript(agentScript);
            return Ok(agent);
        }

        [HttpGet("script/{uuid}")]
        public async Task<IActionResult> GetScriptCmdByUuid([FromRoute] string uuid)
        {
            var script = await _agentScriptCmdService.GetAgentScriptCmdByUuid(uuid);
            return Ok(script);
        }

        [HttpGet("script/all")]
        public async Task<IActionResult> GetAllScriptCmd()
        {
            var listScripts = await _agentScriptCmdService.GetAllScripts();
            return Ok(listScripts);
        }
    }
}
