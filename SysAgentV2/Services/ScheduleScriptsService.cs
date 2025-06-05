using AutoMapper;
using SysAgentV2.DTOs;
using SysAgentV2.Models.Schedulling;
using SysAgentV2.Repository.Interfaces;
using SysAgentV2.Services.Interfaces;

namespace SysAgentV2.Services
{
    public class ScheduleScriptsService : IScheduleScriptsService
    {
        private readonly IScheduleScriptsRepository _scheduleScriptsRepository;
        private readonly IMapper _mapper;
        public ScheduleScriptsService(IScheduleScriptsRepository scheduleScriptsRepository, IMapper mapper)
        {
            _scheduleScriptsRepository = scheduleScriptsRepository;
            _mapper = mapper;
        }

        public async Task<ScheduleScripts> CreateScheduleScriptAsync(ScheduleScriptsDto scheduleScriptsDto)
        {
            var model = _mapper.Map<ScheduleScripts>(scheduleScriptsDto);
            return await _scheduleScriptsRepository.CreateScheduleScript(model);
        }

        public async Task<IEnumerable<ScheduleScriptsDto>> GetAllScheduleScriptAsync()
        {
            var listModel = await _scheduleScriptsRepository.GetAllScheduleScript();
            var listDto = _mapper.Map<IEnumerable<ScheduleScriptsDto>>(listModel);
            return listDto;
        }
    }
}
