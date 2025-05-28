using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysAgentV2.Models.Schedulling
{
    [Table("t_schedules")]
    [Index(nameof(TagSchedule), IsUnique = true)]
    public class Schedule : ModelBase
    {
        [Column("tag_schedule")]
        [Required]
        public string? TagSchedule { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("time")]
        [Required]
        public TimeSpan Time { get; set; }

        [Column("days_of_week")]
        [Required]
        public string? DaysOfWeek { get; set; }
    }
}
