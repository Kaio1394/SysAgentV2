using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysAgentV2.Models
{
    [Table("t_repo_scripts_file")]
    public class AgentScripFile: ModelBase
    {
        [Column("file_path")]
        [Required]
        public string? FilePath { get; set; }

        [Column("language")]
        [Required]
        public string? Language { get; set; }

        [Column("output")]
        [Required]
        public string? Output { get; set; }

        [Column("is_chained")]
        public bool IsChained { get; set; } = false;
    }
}
