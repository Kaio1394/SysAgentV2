using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SysAgentV2.Enum;
using SysAgentV2.Models;
using SysAgentV2.Models.response;
using SysAgentV2.Services.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace SysAgentV2.Controllers
{
    [ExcludeFromCodeCoverage]
    [ApiController]
    [Route("api/[controller]")]
    public class AgentExecutionStatusController : Controller
    {
        private readonly IAgentExecutionStatusService _agentExecutionStatusService;
        private readonly ILogger<AgentExecutionStatusController> _logger;

        public AgentExecutionStatusController(IAgentExecutionStatusService agentExecutionStatusService, ILogger<AgentExecutionStatusController> logger) 
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
            var updateSuccessfull = await _agentExecutionStatusService.UpdateStatusAsync((int)ExecutionStatus.RUNNING);
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
            var updateSuccessfull = await _agentExecutionStatusService.UpdateStatusAsync((int)ExecutionStatus.STOPPED);
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
