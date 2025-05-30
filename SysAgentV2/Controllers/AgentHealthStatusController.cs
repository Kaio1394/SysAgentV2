using Hardware.Info;
using Microsoft.AspNetCore.Mvc;
using SysAgentV2.Helpers.Interfaces;
using SysAgentV2.Models;
using SysAgentV2.Services.Interfaces;
using System.Diagnostics;

namespace SysAgentV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgentHealthStatusController : ControllerBase
    {
        private readonly IHelper _helper;
        private readonly IAgentHealthStatusService _agentHealthStatusService;
        private readonly ILogger<AgentHealthStatusController> _logger;
        public AgentHealthStatusController(IHelper helper, IAgentHealthStatusService agentHealthStatusService, ILogger<AgentHealthStatusController> logger)
        {
            _helper = helper;
            _agentHealthStatusService = agentHealthStatusService;
            _logger = logger;
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetHealthStatus()
        {
            _logger.LogInformation($"Call endpoint {nameof(GetHealthStatus)}");
            var healthStatus = await _agentHealthStatusService.GetHealthStatusAsync();
            _logger.LogInformation($"{healthStatus}");
            return Ok(healthStatus);
        }

        [HttpPost("agent/active")]
        public async Task<IActionResult> ActiveAgent()
        {
            var activeAgent = await _agentHealthStatusService.ActivateAgentAsync();
            if (!activeAgent)
                return BadRequest();
            return Ok(new
            {
                Message = "Activate agent with successfull!"
            });
        }
        [HttpPost("agent/disable")]
        public async Task<IActionResult> DisableAgent()
        {
            var activeAgent = await _agentHealthStatusService.DisableAgentAsync();
            if (!activeAgent)
                return BadRequest();
            return Ok(new
            {
                Message = "Disable agent with successfull!"
            });
        }
    }
}
