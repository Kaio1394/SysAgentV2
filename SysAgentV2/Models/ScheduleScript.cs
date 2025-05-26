using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysAgentV2.Models
{
    [Table("t_schedule_scripts")]
    public class ScheduleScript
    {
        [Key]
        [Column("uuid")]
        [Required]
        public string Uuid { get; set; } = Guid.NewGuid().ToString();

        [Column("script_uuid")]
        [ForeignKey("Script")]
        [Required]
        public string ScriptUuid { get; set; }
        public AgentScriptCmd Script { get; set; } = null!;

        [Column("execution_time")]
        [Required]
        public TimeSpan ExecutionTime { get; set; }

        [Column("days_of_week")]
        [Required]
        public string DaysOfWeek { get; set; }
    }
}
