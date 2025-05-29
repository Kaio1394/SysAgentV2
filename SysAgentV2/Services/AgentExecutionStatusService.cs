using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SysAgentV2.DTOs;
using SysAgentV2.Models;
using SysAgentV2.Repository.Interfaces;
using SysAgentV2.Services.Interfaces;

namespace SysAgentV2.Services
{
    public class AgentExecutionStatusService : IAgentExecutionStatusService
    {
        private readonly IAgentExecutionStatusRepository _repository;
        private readonly IMapper _mapper;

        public AgentExecutionStatusService(IAgentExecutionStatusRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AgentExecutionStatusDto?> GetStatusAsync()
        {
            var agentModel = await _repository.GetByIdAsync();
            return _mapper.Map<AgentExecutionStatusDto>(agentModel);
        }

        public async Task<bool> UpdateStatusAsync(int statusInt)
        {
            return await _repository.UpdateAsync(statusInt);
        }
    }
}
