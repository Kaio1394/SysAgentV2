using SysAgentV2.DTOs;

namespace SysAgentV2.Models
{
    public class Metrics
    {
        public Memory Memory { get; set; }
        public Cpu Cpu { get; set; }
        public Disk Disk { get; set; }
    }
}
