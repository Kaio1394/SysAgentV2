using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysAgentUnitTest.Mock
{
    public class SystemMetrics
    {
        public SysAgentV2.Models.Infos.Memory Memory { get; set; }
        public SysAgentV2.Models.Infos.Cpu Cpu { get; set; }
        public List<SysAgentV2.Models.Infos.Disk> ListDisk { get; set; }
    }
}
