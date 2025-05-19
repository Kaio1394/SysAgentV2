using Hardware.Info;
using Microsoft.AspNetCore.Mvc;
using SysAgentV2.Interfaces;
using SysAgentV2.Models;
using System.Diagnostics;

namespace SysAgentV2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CollectDataController : ControllerBase
    {
        private readonly IHelper _helper;
        public CollectDataController(IHelper helper)
        {
            _helper = helper;
        }

        [HttpGet("info/cpu")]
        public async Task<IActionResult> GetCpuInfo()
        {
            var cpuInfo = await _helper.GetInfoCpuAsync();
            return Ok(cpuInfo);
        }

        [HttpGet("info/memory")]
        public async Task<IActionResult> GetMemoryInfo()
        {
            var memoryInfo = await _helper.GetMemoryInfoAsync();
            return Ok(memoryInfo);
        }

        [HttpGet("info/disk")]
        public async Task<IActionResult> GetDiskInfo()
        {
            var diskInfo = await _helper.GetInfoDiskAsync();
            return Ok(diskInfo);
        }
        [HttpGet("info/hardware")]
        public async Task<IActionResult> GetHardwareInfo()
        {
            var diskInfo = await _helper.GetHardwareInfoAsync();
            return Ok(diskInfo);
        }
    }
}
