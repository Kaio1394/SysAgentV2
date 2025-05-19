using Hardware.Info;
using SysAgentV2.Interfaces;
using System.Diagnostics;
using System.Management;

namespace SysAgentV2.Helpers
{
    public class AgentHardwareInfo : IAgentHardwareInfo
    {
        public int GetQtyCore()
        {
            return Environment.ProcessorCount;
        }
        public uint GetCpuFrequency()
        {
            try
            {
                var hardwareInfo = new HardwareInfo();
                hardwareInfo.RefreshCPUList();

                var cpu = hardwareInfo.CpuList.FirstOrDefault();
                return cpu.MaxClockSpeed;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string GetProcessorName()
        {
            string cpuName = "Desconhecido";
            try
            {
                using var searcher = new ManagementObjectSearcher("select Name from Win32_Processor");
                foreach (ManagementObject obj in searcher.Get())
                {
                    cpuName = obj["Name"]?.ToString() ?? "Desconhecido";
                    break;
                }
                return cpuName.Trim();
            }
            catch
            {
                return "Desconhecido";
            }
        }

        public float GetCpuUsage()
        {
            try
            {
                using var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

                _ = cpuCounter.NextValue();

                System.Threading.Thread.Sleep(1000);

                float cpuUsage = cpuCounter.NextValue();
                return cpuUsage;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Models.Cpu GetInfoCpu()
        {
            return new Models.Cpu()
            {
                NameProcessor = GetProcessorName(),
                Core = GetQtyCore(),
                Frequency = GetCpuFrequency(),
                UsagePercent = GetCpuUsage(),
            };
        }

        public List<Models.Disk> GetInfoDisk()
        {
            List<Models.Disk> list = new List<Models.Disk>();

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    long totalSpace = drive.TotalSize / (1024 * 1024 * 1024);
                    long freeSpace = drive.TotalFreeSpace / (1024 * 1024 * 1024);
                    long usedSpace = totalSpace - freeSpace;

                    list.Add(new Models.Disk()
                    {
                        Name = drive.Name,
                        Info = new Models.DictioaryInfoDisk()
                        {
                            TotalSpace = totalSpace,
                            UsedSpace = usedSpace,
                            FreeSpace = freeSpace,
                        }
                    });
                }
            }
            return list;
        }

        public Models.Memory GetInfoMemory()
        {
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_OperatingSystem");
            Models.Memory? memory = new Models.Memory();
            foreach (var obj in searcher.Get())
            {
                double totalVisibleMemory = Convert.ToDouble(obj["TotalVisibleMemorySize"]) / 1024; 
                double freePhysicalMemory = Convert.ToDouble(obj["FreePhysicalMemory"]) / 1024;   
                double usedMemory = totalVisibleMemory - freePhysicalMemory;

                memory.Total = $"{totalVisibleMemory:F2} MB";
                memory.Free = $"{freePhysicalMemory:F2} MB";
                memory.Usage = $"{usedMemory:F2} MB";
            }
            return memory;
        }

        

        
    }
}
