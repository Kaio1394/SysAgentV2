using Microsoft.AspNetCore.Mvc;
using SysAgentV2.Models.Schedulling;
using SysAgentV2.Services.Interfaces;

namespace SysAgentV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ScheduleController : Controller
    {
        private readonly IScheduleService _scheduleService;

        public ScheduleController(IScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateSchedule([FromBody] Schedule schedule)
        {
            var sc = await _scheduleService.CreateScheduleAsync(schedule);
            return Ok(sc);    
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllSchedule()
        {
            var listSchedule = await _scheduleService.GetAllScheduleAsync();
            return Ok(listSchedule);
        }
    }
}
