using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SysAgentV2.Models
{
    [ExcludeFromCodeCoverage]
    [Table("t_health_statust")]
    public class HealthStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; } = 1;

        [Column("status")]
        [Required]
        [MaxLength(100)]
        public string Status { get; set; } = "DISABLED";

        [Column("edited_at")]
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
