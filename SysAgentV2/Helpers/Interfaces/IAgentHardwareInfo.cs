using SysAgentV2.Models;

namespace SysAgentV2.Helpers.Interfaces
{
    public interface IAgentHardwareInfo
    {
        string GetProcessorName();
        uint GetCpuFrequency();
        float GetCpuUsage();
        int GetQtyCore();
        List<Models.Disk> GetInfoDisk();
        Models.Memory GetInfoMemory();
        Models.Cpu GetInfoCpu();
        List<Models.Process> GetListProcess();
        Models.Process GetProcessByPid(int pid);
        (bool, Models.Process) KillProcessByPid(int pid);
        List<Models.Service> GetListServices();
        bool StopServiceByDisplayName(string displayName);
        bool StopServiceByServiceName(string serviceName);
        bool StartServiceByDisplayName(string displayName);
        List<EventView> GetEventViewList(string logName, string date, string lastTime);
    }
}
