using Microsoft.AspNetCore.Mvc;
using SysAgentV2.Services.Interfaces;

namespace SysAgentV2.Controllers
{
    public class AgentStatusController : Controller
    {
        private readonly IAgentStatusService _agentStatusService;
        public AgentStatusController(IAgentStatusService agentStatusService) 
        {
            _agentStatusService = agentStatusService;
        }

        [HttpGet("status")]
        public async Task<IActionResult> Get()
        {
            var agent = await _agentStatusService.GetStatusAsync();
            return Ok(agent);
        }
    }
}
