using SysAgentV2.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SysAgentV2.Models
{
    [ExcludeFromCodeCoverage]
    [Table("t_status_health")]
    public class AgentHealthStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; } = 1;

        [Column("health_status")]
        [Required]
        public string HealthStatus { get; set; } = Enum.HealthStatus.DISABLED.ToString();

        [Column("edited_at")]
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
