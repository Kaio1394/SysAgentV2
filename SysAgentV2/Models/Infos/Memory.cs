using System.Diagnostics.CodeAnalysis;

namespace SysAgentV2.Models.Infos
{
    [ExcludeFromCodeCoverage]
    public class Memory
    {
        public string Usage { get; set; }
        public string Total { get; set; }
        public string Free { get; set; }
    }
}
