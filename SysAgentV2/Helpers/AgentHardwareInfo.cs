using Hardware.Info;
using SysAgentV2.Interfaces;
using System.Diagnostics;
using System.Management;

namespace SysAgentV2.Helpers
{
    public class AgentHardwareInfo : IAgentHardwareInfo
    {
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

        public int GetQtyCore()
        {
            return Environment.ProcessorCount;
        }
    }
}
