using AutoMapper;
using SysAgentV2.Models;
using SysAgentV2.Models.Schedulling;
using System.Diagnostics.CodeAnalysis;

namespace SysAgentV2.DTOs.Mappings
{
    [ExcludeFromCodeCoverage]
    public class AgentProfile : Profile
    {
        public AgentProfile()
        {
            CreateMap<AgentExecutionStatus, AgentExecutionStatusDto>().ReverseMap();
            CreateMap<ScheduleScripts, ScheduleScriptsDto>().ReverseMap();
        }
    }
}
