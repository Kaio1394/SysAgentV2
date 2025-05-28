using SysAgentV2.Models.Infos;

namespace SysAgentV2.Helpers.Interfaces
{
    public interface IHelper
    {
        Task<Memory> GetMemoryInfoAsync();
        Task<List<Disk>> GetInfoDiskAsync();
        Task<List<Process>> GetInfoProcessAsync();
        Task<Process> GetProcessByPidAsync(int pid);
        Task<Cpu> GetInfoCpuAsync();
        Task<Metrics> GetHardwareInfoAsync();
        Task<List<Service>> GetListServicesAsync();
        Task<bool> StopServiceByDisplayNameAsync(string displayName);
        Task<bool> StartServiceByDisplayNameAsync(string displayName);
        Task<List<EventView>> GetEventViewList(string logName, string date, string lastTime);
        Task<string> ExecuteScriptCmd(string script);

    }
}
