using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SysAgentV2.Models;
using SysAgentV2.Services.Interfaces;

namespace SysAgentV2.Controllers
{
    public class AgentController : Controller
    {
        private readonly IAgentStatusService _agentStatusService;
        const string RUNNING = "RUNNING";
        const string STOPPED = "STOPPED";
        public AgentController(IAgentStatusService agentStatusService) 
        {
            _agentStatusService = agentStatusService;
        }

        [HttpGet("collect/data/status")]
        public async Task<IActionResult> Get()
        {
            var agent = await _agentStatusService.GetStatusAsync();
            return Ok(agent);
        }
        [HttpPost("collect/data/start")]
        public async Task<IActionResult> StartCollectData()
        {
            var updateSuccessfull = await _agentStatusService.UpdateStatusAsync(RUNNING);
            var response = new AgentResponse()
            {
                Info = new Info()
                {
                    Text = "Started agent to colect data hardware."
                }
            };
            if (updateSuccessfull)
                return Ok(response);
            response.Info.Text = "Error to start agent to colect data hardware.";
            return BadRequest(response);
        }
        [HttpPost("collect/data/stop")]
        public async Task<IActionResult> StopCollectData()
        {
            var updateSuccessfull = await _agentStatusService.UpdateStatusAsync(STOPPED);
            var response = new AgentResponse()
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
