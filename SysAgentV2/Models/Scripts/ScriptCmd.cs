using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysAgentV2.Models.Scripts
{
    [Table("t_repo_scripts_cmd")]
    public class ScriptCmd : ModelBase
    {
        [Column("tag")]
        [Required]
        public string? Tag { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("script")]
        [Required]
        public string? Script { get; set; }
    }
}
