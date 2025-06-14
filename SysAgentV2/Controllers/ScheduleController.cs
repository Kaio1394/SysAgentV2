using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using SysAgentV2.Models.Schedulling;
using SysAgentV2.Services.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace SysAgentV2.Controllers
{
    [ExcludeFromCodeCoverage]
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
        [HttpGet("by-uuid/{uuid}")]
        public async Task<IActionResult> GetScheduleByUuid([FromRoute] string uuid)
        {
            var schedule = await _scheduleService.GetScheduleByUuidAsync(uuid);
            if (schedule == null)
                return BadRequest(new
                {
                    Message = "Schedule not found."
                });
            return Ok(schedule);
        }
        [HttpGet("by-tag/{tag}")]
        public async Task<IActionResult> GetScheduleByTag([FromRoute] string tag)
        {
            var schedule = await _scheduleService.GetScheduleByTagAsync(tag);
            if (schedule == null)
                return BadRequest(new
                {
                    Message = "Schedule not found."
                });
            return Ok(schedule);
        }
        [HttpDelete("")]
        public async Task<IActionResult> DeleteScheduleByUuid([FromHeader] string uuid)
        {
            var deletedSchedule = await _scheduleService.DeleteScheduleByUuidAsync(uuid);
            if (!deletedSchedule)
                return BadRequest();
            return Ok(new
            {
                Message = "Deleted schedule with successfull."
            });
        }
    }
}
