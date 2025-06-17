using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace SysAgentV2.DTOs
{
    [ExcludeFromCodeCoverage]
    public class AgentExecutionStatusDto
    {
        public string Status { get; set; } = "STOPPED";

        public DateTime CreatedAt { get; set; }
    }
}
