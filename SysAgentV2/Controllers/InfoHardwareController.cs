using Hardware.Info;
using Microsoft.AspNetCore.Mvc;
using SysAgentV2.Helpers.Interfaces;
using SysAgentV2.Models;
using SysAgentV2.Models.response;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace SysAgentV2.Controllers
{
    [ExcludeFromCodeCoverage]
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

        [HttpGet("list/process")]
        public async Task<IActionResult> GetListProcessInfo()
        {
            var listProcess = await _helper.GetInfoProcessAsync();
            return Ok(listProcess);
        }

        [HttpGet("list/services")]
        public async Task<IActionResult> GetListServicesInfo()
        {
            var listServices = await _helper.GetListServicesAsync();
            return Ok(listServices);
        }

        [HttpGet("process/{pid}")]
        public async Task<IActionResult> ProcessInfo([FromRoute] int pid)
        {
            var process = await _helper.GetProcessByPidAsync(pid);

            if(process == null)
                return NotFound(new InfoError
                {
                    Error = "Process not found."
                });
            return Ok(process);
        }
    }
}
