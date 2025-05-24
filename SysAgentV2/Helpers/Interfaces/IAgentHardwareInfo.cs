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
    }
}
