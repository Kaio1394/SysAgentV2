using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysAgentV2.Models
{
    [Table("t_status_agent")]
    public class AgentStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; } = 1;

        [Column("status")]
        [Required]
        [MaxLength(100)]
        public string Status { get; set; } = "STOPPED";

        [Column("edited_at")]
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
