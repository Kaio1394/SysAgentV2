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

        [HttpPost("script")]
        public async Task<IActionResult> CreateScriptCmd([FromBody] AgentScriptCmd agentScript)
        {
            var agent = await _agentScriptCmdService.CreateScript(agentScript);
            if (agent == null)
                return Conflict(new { message = "Script with the same tag already exists." });
            return Ok(agent);
        }

        [HttpPut("script")]
        public async Task<IActionResult> UpdateScriptCmd([FromBody] AgentScriptCmd agentScript)
        {
            var agent = await _agentScriptCmdService.UpdateAsync(agentScript);
            if (agent == null)
                return NotFound(new { message = "Script not found." });
            return Ok(agent);
        }

        [HttpDelete("script")]
        public async Task<IActionResult> DeleteScriptCmd([FromHeader] string uuid)
        {
            var deleted = await _agentScriptCmdService.DeleteScript(uuid);
            if(deleted)
                return Ok(new
                {
                    message = "Delete with successfull."
                });
            return BadRequest();
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
