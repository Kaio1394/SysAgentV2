using System.Diagnostics.CodeAnalysis;

namespace SysAgentV2.Models.Infos
{
    [ExcludeFromCodeCoverage]
    public class Cpu
    {
        public string? NameProcessor { get; set; }
        public float Frequency { get; set; }
        public int Core { get; set; }
        public double UsagePercent { get; set; }
    }
}
