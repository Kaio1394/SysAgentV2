using SysAgentV2.Models.Schedulling;
using SysAgentV2.Models.Scripts;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysAgentV2.DTOs
{
    public class ScheduleScriptsDto
    {
        public string? ScheduleUuid { get; set; }
        public string? ScriptsUuid { get; set; }
        public int ExecutionOrder { get; set; }
    }
}
