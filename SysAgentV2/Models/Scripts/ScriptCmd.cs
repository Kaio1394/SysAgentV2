using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SysAgentV2.Models.Scripts
{
    [ExcludeFromCodeCoverage]
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
