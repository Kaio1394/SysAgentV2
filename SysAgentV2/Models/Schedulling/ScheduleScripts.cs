using Microsoft.EntityFrameworkCore;
using SysAgentV2.Models.Scripts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SysAgentV2.Models.Schedulling
{
    [ExcludeFromCodeCoverage]
    [Table("t_schedule_scripts_cmd")]
    public class ScheduleScripts : ModelBase
    {
        // Foreign Key to Schedule Table
        [Column("schedule_uuid")]
        [Required]
        public string? ScheduleUuid { get; set; }

        [ForeignKey(nameof(ScheduleUuid))]
        public Schedule? Schedule { get; set; }

        // Foreign Key to Script Table
        [Column("script_uuid")]
        [Required]
        public string? ScriptsUuid { get; set; }

        [ForeignKey(nameof(ScriptsUuid))]
        public ScriptCmd? ScriptCmd { get; set; }

        [Column("execution_order")]
        [Required]
        public int ExecutionOrder { get; set; }
    }
}
