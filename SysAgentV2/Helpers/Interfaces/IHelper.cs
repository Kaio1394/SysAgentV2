using SysAgentV2.Models;

namespace SysAgentV2.Helpers.Interfaces
{
    public interface IHelper
    {
        Task<Memory> GetMemoryInfoAsync();
        Task<List<Disk>> GetInfoDiskAsync();
        Task<List<Models.Process>> GetInfoProcessAsync();
        Task<Models.Process> GetProcessByPidAsync(int pid);
        Task<Cpu> GetInfoCpuAsync();
        Task<Metrics> GetHardwareInfoAsync();
        Task<List<Models.Service>> GetListServicesAsync();
        Task<bool> StopServiceByDisplayNameAsync(string displayName);
        Task<bool> StartServiceByDisplayNameAsync(string displayName);
        Task<List<Models.EventView>> GetEventViewList(string logName, string date, string lastTime);
    }
}
