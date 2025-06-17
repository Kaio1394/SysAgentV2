using System.Diagnostics.CodeAnalysis;

namespace SysAgentV2.Models.response
{
    [ExcludeFromCodeCoverage]
    public class AgentStatusResponse
    {
        public Info Info { get; set; }
    }
    [ExcludeFromCodeCoverage]
    public class Info
    {
        public string Text { get; set; }
    }
}
