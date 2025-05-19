using Hardware.Info;
using SysAgentV2.Interfaces;
using SysAgentV2.Models;
using System.Diagnostics;
using System.Management;

namespace SysAgentV2.Helpers
{
    public class Helper: IHelper
    {
        private readonly IAgentHardwareInfo _hardwareInfo;
        public Helper(IAgentHardwareInfo hardwareInfo)
        {
            _hardwareInfo = hardwareInfo;
        }

        public Task<Models.Memory> GetMemoryInfoAsync()
        {
            return Task.Run(() =>
            {
                var memoryInfo = _hardwareInfo.GetInfoMemory();
                return memoryInfo;
            });
        }

        public Task<List<Models.Disk>> GetInfoDiskAsync()
        {
            return Task.Run(() =>
            {
                var dictInfoDisk = _hardwareInfo.GetInfoDisk();
                return dictInfoDisk;
            });
        }
        public Task<Metrics> GetHardwareInfoAsync()
        {
            return Task.Run(() => {
                var dictInfoDisk = _hardwareInfo.GetInfoDisk();

                var memoryInfo = _hardwareInfo.GetInfoMemory();

                var cpuInfo = _hardwareInfo.GetInfoCpu();

                var metrics = new Metrics()
                {
                    Cpu = cpuInfo,
                    Memory = memoryInfo,
                    ListDisk = dictInfoDisk,
                };

                return metrics;
            });
        }

        public Task<Cpu> GetInfoCpuAsync()
        {
            return Task.Run(() =>
            {
                var cpuInfo = _hardwareInfo.GetInfoCpu();
                return cpuInfo;
            });
        }
    }
}
