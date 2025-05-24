using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SysAgentV2.DTOs;
using SysAgentV2.Models;
using SysAgentV2.Repository.Interfaces;
using SysAgentV2.Services.Interfaces;

namespace SysAgentV2.Services
{
    public class AgentHealthStatusService : IAgentHealthStatusService
    {
        private readonly IAgentExecutionStatusRepository _repository;
        private readonly IMapper _mapper;

        public AgentHealthStatusService(IAgentExecutionStatusRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AgentExecutionStatusDto?> GetHealthStatusAsync()
        {
            var agentModel = await _repository.GetByIdAsync();
            return _mapper.Map<AgentExecutionStatusDto>(agentModel);
        }

        public async Task<bool> UpdateHealthStatusAsync(string status)
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
