using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SysAgentV2.Models
{
    [Table("t_collect_metrics")]
    public class CollectMetrics : ModelBase
    {
        [Column("json_result")] 
        [Required] 
        [MaxLength(100)]
        public string JsonResult { get; set; }
    }
}
