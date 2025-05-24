using Hardware.Info;
using Microsoft.AspNetCore.Mvc;
using SysAgentV2.Helpers.Interfaces;
using SysAgentV2.Models;
using System.Diagnostics;

namespace SysAgentV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgentHealthStatusController : ControllerBase
    {
        private readonly IHelper _helper;
        public AgentHealthStatusController(IHelper helper)
        {
            _helper = helper;
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetCpuInfo()
        {
            var cpuInfo = await _helper.GetInfoCpuAsync();
            return Ok(cpuInfo);
        }
    }
}
