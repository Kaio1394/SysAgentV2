using AutoMapper;
using SysAgentV2.Models;

namespace SysAgentV2.DTOs.Mappings
{
    public class AgentStatusProfile : Profile
    {
        public AgentStatusProfile()
        {
            CreateMap<AgentStatus, AgentStatusDto>();
        }
    }
}
