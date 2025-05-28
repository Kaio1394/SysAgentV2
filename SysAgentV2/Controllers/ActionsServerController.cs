using Hardware.Info;
using Microsoft.AspNetCore.Mvc;
using SysAgentV2.Helpers.Interfaces;
using SysAgentV2.Models;
using SysAgentV2.Services.Interfaces;
using System.Diagnostics;

namespace SysAgentV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActionsServerController : ControllerBase
    {
        private readonly IHelper _helper;
        private readonly IScriptCmdService _ScriptCmdService;
        public ActionsServerController(IHelper helper, IScriptCmdService ScriptCmdService)
        {
            _helper = helper;
            _ScriptCmdService = ScriptCmdService;
        }

        [HttpPost("kill/process/{pid}")]
        public async Task<IActionResult> KillService([FromRoute] int pid)
        {
            var cpuInfo = await _helper.GetInfoCpuAsync();
            return Ok(cpuInfo);
        }

        [HttpPost("stop/service/{displayName}")]
        public async Task<IActionResult> StopServiceByDisplayName([FromRoute] string displayName)
        {
            var serviceStopped = await _helper.StopServiceByDisplayNameAsync(displayName);

            if(serviceStopped)
                return Ok(new
                {
                    Info = "Service stopepd with successfull."
                });
            return BadRequest(new
            {
                Info = "Service not stopepd with successfull."
            });
        }

        [HttpPost("execute/script/{uuid}")]
        public async Task<IActionResult> ExecuteSCriptCmd([FromRoute] string uuid)
        {
            var script = await _ScriptCmdService.GetScriptCmdByUuid(uuid);
            if (script == null)
                return NotFound(new
                {
                    Info = "Script cmd not found."
                });
            if (string.IsNullOrEmpty(script.Script))
                return BadRequest(new
                {
                    Info = "The column script is empty."
                });
            var output = await _helper.ExecuteScriptCmd(script.Script);
            return Ok(new
            {
                Tag = $"{script.Tag}",
                Script = script.Script,
                Output = output
            });
        }

        [HttpPost("start/service/{displayName}")]
        public async Task<IActionResult> StartServiceByDisplayNam([FromRoute] string displayName)
        {
            var serviceStopped = await _helper.StartServiceByDisplayNameAsync(displayName);

            if (serviceStopped)
                return Ok(new
                {
                    Info = "Service started with successfull."
                });
            return BadRequest(new
            {
                Info = "Service not started with successfull."
            });
        }
    }
}
