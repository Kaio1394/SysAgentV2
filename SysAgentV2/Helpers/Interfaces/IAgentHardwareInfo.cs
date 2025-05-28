using SysAgentV2.Models.Infos;

namespace SysAgentV2.Helpers.Interfaces
{
    public interface IAgentHardwareInfo
    {
        string GetProcessorName();
        uint GetCpuFrequency();
        float GetCpuUsage();
        int GetQtyCore();
        List<Disk> GetInfoDisk();
        Memory GetInfoMemory();
        Cpu GetInfoCpu();
        List<Process> GetListProcess();
        Process GetProcessByPid(int pid);
        (bool, Process) KillProcessByPid(int pid);
        List<Service> GetListServices();
        bool StopServiceByDisplayName(string displayName);
        bool StopServiceByServiceName(string serviceName);
        bool StartServiceByDisplayName(string displayName);
        List<EventView> GetEventViewList(string logName, string date, string lastTime);
        string ExecuteScriptCmd(string script);
    }
}
