using SysAgentV2.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysAgentV2.Models
{
    [Table("t_status_health")]
    public class AgentHealthStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; } = 1;

        [Column("health_status")]
        [Required]
        public string HealthStatus { get; set; } = Enum.AgentHealthStatus.DISABLED.ToString();

        [Column("edited_at")]
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
