using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SysAgentV2.Models.Scripts;
using SysAgentV2.Services.Interfaces;

namespace SysAgentV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgentScriptsCmdController : Controller
    {
        private readonly IScriptCmdService _ScriptCmdService;
        public AgentScriptsCmdController(IScriptCmdService ScriptCmdService) 
        {
            _ScriptCmdService = ScriptCmdService;
        }

        [HttpPost("script")]
        public async Task<IActionResult> CreateScriptCmd([FromBody] ScriptCmd agentScript)
        {
            var agent = await _ScriptCmdService.CreateScript(agentScript);
            if (agent == null)
                return Conflict(new { message = "Script with the same tag already exists." });
            return Ok(agent);
        }

        [HttpPut("script")]
        public async Task<IActionResult> UpdateScriptCmd([FromBody] ScriptCmd agentScript)
        {
            var agent = await _ScriptCmdService.UpdateAsync(agentScript);
            if (agent == null)
                return NotFound(new { message = "Script not found." });
            return Ok(agent);
        }

        [HttpDelete("script")]
        public async Task<IActionResult> DeleteScriptCmd([FromHeader] string uuid)
        {
            var deleted = await _ScriptCmdService.DeleteScript(uuid);
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
            var script = await _ScriptCmdService.GetScriptCmdByUuid(uuid);
            return Ok(script);
        }

        [HttpGet("script/all")]
        public async Task<IActionResult> GetAllScriptCmd()
        {
            var listScripts = await _ScriptCmdService.GetAllScripts();
            return Ok(listScripts);
        }
    }
}
