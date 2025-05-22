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

        public async Task<AgentDto?> GetStatusAsync()
        {
            var agentModel = await _repository.GetByIdAsync();
            return _mapper.Map<AgentDto>(agentModel);
        }

        public async Task<bool> UpdateStatusAsync(string status)
        {
            var agentModel = await _repository.GetByIdAsync();

            if (agentModel == null)
                return false;

            agentModel.Status = status;

            _repository.Update(agentModel);
            return await _repository.SaveChanges();
        }
    }
}
