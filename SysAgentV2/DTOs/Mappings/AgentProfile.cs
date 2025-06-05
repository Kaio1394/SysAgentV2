using AutoMapper;
using SysAgentV2.Models;
using SysAgentV2.Models.Schedulling;

namespace SysAgentV2.DTOs.Mappings
{
    public class AgentProfile : Profile
    {
        public AgentProfile()
        {
            CreateMap<AgentExecutionStatus, AgentExecutionStatusDto>().ReverseMap();
            CreateMap<ScheduleScripts, ScheduleScriptsDto>().ReverseMap();
        }
    }
}
