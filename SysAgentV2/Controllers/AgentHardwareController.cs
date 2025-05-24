using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SysAgentV2.Enum;
using SysAgentV2.Models;
using SysAgentV2.Models.response;
using SysAgentV2.Services.Interfaces;

namespace SysAgentV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgentHardwareController : Controller
    {
        private readonly IAgentExecutionStatusService _agentExecutionStatusService;
        private readonly ILogger<AgentHardwareController> _logger;

        public AgentHardwareController(IAgentExecutionStatusService agentExecutionStatusService, ILogger<AgentHardwareController> logger) 
        {
            _agentExecutionStatusService = agentExecutionStatusService;
            _logger = logger;
        }

        [HttpGet("status")]
        public async Task<IActionResult> Get()
        {
            var agent = await _agentExecutionStatusService.GetStatusAsync();
            return Ok(agent);
        }
        [HttpPost("start")]
        public async Task<IActionResult> StartCollectData()
        {
            _logger.LogInformation($"Call endpoint {ControllerContext.ActionDescriptor.DisplayName}.");
            var updateSuccessfull = await _agentExecutionStatusService.UpdateStatusAsync(ExecutionStatus.RUNNING.ToString());
            var response = new AgentStatusResponse()
            {
                Info = new Info()
                {
                    Text = "Started agent to colect data hardware."
                }
            };
            if (updateSuccessfull) 
            {
                _logger.LogInformation(response.Info.Text);
                return Ok(response);
            }
                
            response.Info.Text = "Error to start agent to colect data hardware.";
            _logger.LogInformation(response.Info.Text);
            return BadRequest(response);
        }
        [HttpPost("stop")]
        public async Task<IActionResult> StopCollectData()
        {
            var updateSuccessfull = await _agentExecutionStatusService.UpdateStatusAsync(ExecutionStatus.STOPPED.ToString());
            var response = new AgentStatusResponse()
            {
                Info = new Info()
                {
                    Text = "Stopped agent to colect data hardware."
                }
            };
            if (updateSuccessfull)
                return Ok(response);
            response.Info.Text = "Error to stop agent to colect data hardware.";
            return BadRequest(response);
        }
    }
}
