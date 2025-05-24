using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SysAgentV2.Models;
using SysAgentV2.Services.Interfaces;

namespace SysAgentV2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AgentScriptsController : Controller
    {
        private readonly IAgentExecutionStatusService _agentStatusService;
        public AgentScriptsController(IAgentExecutionStatusService agentStatusService) 
        {
            _agentStatusService = agentStatusService;
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get()
        {
            var agent = await _agentStatusService.GetStatusAsync();
            return Ok(agent);
        }
        [HttpPost("create/script")]
        public async Task<IActionResult> Post()
        {
            var agent = await _agentStatusService.GetStatusAsync();
            return Ok(agent);
        }
    }
}
