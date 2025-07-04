﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace SysAgentV2.Models
{
    [ExcludeFromCodeCoverage]
    [Table("t_collect_metrics")]
    public class CollectMetrics
    {
        [Key]
        [Column("uuid")]
        [Required]
        public string Uuid { get; set; } = Guid.NewGuid().ToString();
    
        [Column("json_result")] 
        [Required] 
        [MaxLength(100)]
        public string? JsonResult { get; set; }

        [Column("collect_at")]
        [Required]
        public DateTime CollectdAt { get; set; } = DateTime.UtcNow;
    }
}
