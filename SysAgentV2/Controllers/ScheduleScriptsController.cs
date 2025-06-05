using Microsoft.AspNetCore.Mvc;
using SysAgentV2.DTOs;
using SysAgentV2.Models.Schedulling;
using SysAgentV2.Services.Interfaces;

namespace SysAgentV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleScriptsController : Controller
    {
        private readonly IScheduleScriptsService _scheduleScriptsService;
        public ScheduleScriptsController(IScheduleScriptsService scheduleScriptsService)
        {
            _scheduleScriptsService = scheduleScriptsService;
        }

        [HttpPost("")]
        public async Task<IActionResult> CreateScheduleScript([FromBody] ScheduleScriptsDto cheduleScriptsDto)
        {
            var scheduleScript = await _scheduleScriptsService.CreateScheduleScriptAsync(cheduleScriptsDto);
            return Ok(scheduleScript);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetAllScheduleScript()
        {
            var listScheduleScript = await _scheduleScriptsService.GetAllScheduleScriptAsync();
            return Ok(listScheduleScript);
        }
    }
}
