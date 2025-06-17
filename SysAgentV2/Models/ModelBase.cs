using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SysAgentV2.Models
{
    [ExcludeFromCodeCoverage]
    public class ModelBase
    {
        [Key]
        [Column("uuid")]
        [Required]
        public string Uuid { get; set; } = Guid.NewGuid().ToString();

        [Column("created_at")]
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
