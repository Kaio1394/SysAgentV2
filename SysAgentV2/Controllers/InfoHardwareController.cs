using Hardware.Info;
using Microsoft.AspNetCore.Mvc;
using SysAgentV2.Helpers.Interfaces;
using SysAgentV2.Models;
using System.Diagnostics;

namespace SysAgentV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InfoHardwareController : ControllerBase
    {
        private readonly IHelper _helper;
        public InfoHardwareController(IHelper helper)
        {
            _helper = helper;
        }

        [HttpGet("cpu")]
        public async Task<IActionResult> GetCpuInfo()
        {
            var cpuInfo = await _helper.GetInfoCpuAsync();
            return Ok(cpuInfo);
        }

        [HttpGet("memory")]
        public async Task<IActionResult> GetMemoryInfo()
        {
            var memoryInfo = await _helper.GetMemoryInfoAsync();
            return Ok(memoryInfo);
        }

        [HttpGet("disk")]
        public async Task<IActionResult> GetDiskInfo()
        {
            var diskInfo = await _helper.GetInfoDiskAsync();
            return Ok(diskInfo);
        }
        [HttpGet("hardware")]
        public async Task<IActionResult> GetHardwareInfo()
        {
            var diskInfo = await _helper.GetHardwareInfoAsync();
            return Ok(diskInfo);
        }
    }
}
