using System.Diagnostics.CodeAnalysis;

namespace SysAgentV2.Models.Infos
{
    [ExcludeFromCodeCoverage]
    public class Service
    {
        public string? ServiceName { get; set; }
        public string? DisplayName { get; set; }
        public string? Status { get; set; }
    }
}