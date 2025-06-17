using System.Diagnostics.CodeAnalysis;

namespace SysAgentV2.Models.Infos
{
    [ExcludeFromCodeCoverage]
    public class Metrics
    {
        public Memory? Memory { get; set; }
        public Cpu Cpu { get; set; }
        public List<Disk> ListDisk { get; set; } = new List<Disk>();
    }
}
