using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SysAgentV2.DTOs
{
    public class AgentDto
    {
        public string Status { get; set; } = "STOPPED";

        public DateTime CreatedAt { get; set; }
    }
}
