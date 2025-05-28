using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysAgentV2.Models.Scripts
{
    [Table("t_repo_scripts_file")]
    public class ScripFile : ModelBase
    {
        [Column("tag")]
        [Required]
        public string? Tag { get; set; }

        [Column("description")]
        [Required]
        public string? Description { get; set; }

        [Column("file_path")]
        [Required]
        public string? FilePath { get; set; }

        [Column("language")]
        [Required]
        public string? Language { get; set; }
    }
}
