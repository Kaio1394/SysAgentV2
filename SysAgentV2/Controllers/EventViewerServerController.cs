using Hardware.Info;
using Microsoft.AspNetCore.Mvc;
using SysAgentV2.Helpers.Interfaces;
using SysAgentV2.Models;
using System.Diagnostics;

namespace SysAgentV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventViewerServerController : ControllerBase
    {
        private readonly IHelper _helper;
        public EventViewerServerController(IHelper helper)
        {
            _helper = helper;
        }

        [HttpGet("log/server/{logName}/{date}/{lastOneLogs}")]
        public async Task<IActionResult> GetEnventViewer([FromRoute] string logName, [FromRoute] string date, [FromRoute] string lastOneLogs)
        {
            var listEvenViewr = await _helper.GetEventViewList(logName, date, lastOneLogs);
            return Ok(listEvenViewr);
        }
    }
}
