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
        private readonly IAgentHealthStatusRepository _repository;
        private readonly IMapper _mapper;

        public AgentHealthStatusService(IAgentHealthStatusRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> ActivateAgentAsync()
        {
            return await _repository.ActivateAgentAsync();
        }

        public async Task<bool> DisableAgentAsync()
        {
            return await _repository.DisableAgentAsync();
        }

        public async Task<AgentHealthStatus?> GetHealthStatusAsync()
        {           
            return await _repository.GetHealthStatusAsync();    
        }
    }
}
