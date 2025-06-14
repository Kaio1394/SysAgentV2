using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysAgentUnitTest.Mock
{
    public static class ConstantsMock
    {
        public static string GuidString = Guid.NewGuid().ToString();
        public static string Json_Result = """
                {
                  "Memory": {
                    "Usage": "9607,81 MB",
                    "Total": "16306,71 MB",
                    "Free": "6698,90 MB"
                  },
                  "Cpu": {
                    "NameProcessor": "AMD Ryzen 5 3600 6-Core Processor",
                    "Frequency": 3600,
                    "Core": 12,
                    "UsagePercent": 8.726563453674316
                  },
                  "ListDisk": [
                    {
                      "Name": "C:\\",
                      "Info": {
                        "TotalSpace": 222,
                        "UsedSpace": 200,
                        "FreeSpace": 22
                      }
                    }
                  ]
                }
                """;
    }
}
