using Microsoft.EntityFrameworkCore;
using SysAgentV2.Models;
using SysAgentV2.Repository.Interfaces;
using SysAgentV2.Services.Interfaces;

namespace SysAgentV2.Services
{
    public class AgentStatusService : IAgentStatusService
    {
        private readonly IAgentStatusRepository _repository;

        public AgentStatusService(IAgentStatusRepository repository)
        {
            _repository = repository;
        }

        public Task<AgentStatus?> GetStatusAsync()
        {
            return _repository.GetByIdAsync();
        }

        public async Task<bool> UpdateStatusAsync(AgentStatus agent)
        {
            _repository.Update(agent);
            return await _repository.SaveChanges();
        }
    }
}
