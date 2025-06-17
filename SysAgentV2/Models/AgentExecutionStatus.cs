using SysAgentV2.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SysAgentV2.Models
{
    [ExcludeFromCodeCoverage]
    [Table("t_status_agent")]
    public class AgentExecutionStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; } = 1;

        [Column("status")]
        [Required]
        public string Status { get; set; } = ExecutionStatus.STOPPED.ToString();

        [Column("edited_at")]
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
