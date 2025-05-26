using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysAgentV2.Models
{
    [Table("t_repo_scripts_cmd")]
    public class AgentScriptCmd: ModelBase
    {
        [Column("tag")]
        [Required]
        public string? Tag { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("script")]
        [Required]
        public string? Script { get; set; }

        [Column("is_chained")]
        [Required]
        public bool IsChained { get; set; } = false;
    }
}
