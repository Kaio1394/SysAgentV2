using Hardware.Info;
using Microsoft.AspNetCore.Mvc;
using SysAgentV2.Helpers.Interfaces;
using SysAgentV2.Models;
using System.Diagnostics;

namespace SysAgentV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActionsServerController : ControllerBase
    {
        private readonly IHelper _helper;
        public ActionsServerController(IHelper helper)
        {
            _helper = helper;
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
