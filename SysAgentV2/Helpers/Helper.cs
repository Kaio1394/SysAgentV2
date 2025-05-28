using Hardware.Info;
using SysAgentV2.Helpers.Interfaces;
using SysAgentV2.Models.Infos;
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

        public Task<Models.Infos.Memory> GetMemoryInfoAsync()
        {
            return Task.Run(() =>
            {
                var memoryInfo = _hardwareInfo.GetInfoMemory();
                return memoryInfo;
            });
        }

        public Task<List<Disk>> GetInfoDiskAsync()
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
        public Task<List<Models.Infos.Process>> GetInfoProcessAsync()
        {
            return Task.Run(() =>
            {
                var listProcess = _hardwareInfo.GetListProcess();
                return listProcess;
            });
        }

        public Task<Models.Infos.Process> GetProcessByPidAsync(int pid)
        {
            return Task.Run(() =>
            {
                var process = _hardwareInfo.GetProcessByPid(pid);
                return process;
            });
        }

        public Task<List<Service>> GetListServicesAsync()
        {
            return Task.Run(() =>
            {
                var services = _hardwareInfo.GetListServices();
                return services;
            });
        }

        public Task<bool> StopServiceByDisplayNameAsync(string displayName)
        {
            return Task.Run(() =>
            {
                return _hardwareInfo.StopServiceByDisplayName(displayName);
            });
        }

        public Task<bool> StartServiceByDisplayNameAsync(string displayName)
        {
            return Task.Run(() =>
            {
                return _hardwareInfo.StartServiceByDisplayName(displayName);
            });
        }

        public Task<List<EventView>> GetEventViewList(string logName, string date, string lastTime)
        {
            return Task.Run(() =>
            {
                var listEventView = _hardwareInfo.GetEventViewList(logName, date, lastTime);
                return listEventView;
            });
        }

        public Task<string> ExecuteScriptCmd(string script)
        {
            return Task.Run(() =>
            {
                return _hardwareInfo.ExecuteScriptCmd(script);
            });
        }
    }
}
