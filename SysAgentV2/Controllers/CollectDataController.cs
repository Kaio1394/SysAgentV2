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

        [HttpGet]
        public async Task<IActionResult> GetCpuInfo()
        {
            var cpuUsage = await _helper.GetCpuUsageAsync();
            var qtyCores = await _helper.GetQtyCoreAsync();
            var processor = await _helper.GetNameProcessorAsync();
            var frequency = await _helper.GetCpuFrequencyAsync();
            return Ok(new Cpu{ 
                NameProcessor = processor,
                Frequency = frequency,
                UsagePercent = Convert.ToDouble(cpuUsage.ToString("F2")),
                Core = qtyCores
            });
        }
    }
}
