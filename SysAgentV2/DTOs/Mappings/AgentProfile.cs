using AutoMapper;
using SysAgentV2.Models;

namespace SysAgentV2.DTOs.Mappings
{
    public class AgentProfile : Profile
    {
        public AgentProfile()
        {
            CreateMap<AgentStatus, AgentDto>();
        }
    }
}
