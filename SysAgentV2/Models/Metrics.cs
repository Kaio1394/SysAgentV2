using SysAgentV2.Models;

namespace SysAgentV2.Models
{
    public class Metrics
    {
        public Memory Memory { get; set; }
        public Cpu Cpu { get; set; }
        public List<Disk> ListDisk { get; set; }
    }
}
