using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SysAgentV2.DTOs;
using SysAgentV2.Models;
using SysAgentV2.Repository.Interfaces;
using SysAgentV2.Services.Interfaces;

namespace SysAgentV2.Services
{
    public class AgentStatusService : IAgentStatusService
    {
        private readonly IAgentStatusRepository _repository;
        private readonly IMapper _mapper;

        public AgentStatusService(IAgentStatusRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AgentStatusDto?> GetStatusAsync()
        {
            var agentModel = await _repository.GetByIdAsync();
            return _mapper.Map<AgentStatusDto>(agentModel);
        }

        public async Task<bool> UpdateStatusAsync(AgentStatus agent)
        {
            _repository.Update(agent);
            return await _repository.SaveChanges();
        }
    }
}
