namespace SysAgentV2.Interfaces
{
    public interface IAgentHardwareInfo
    {
        string GetProcessorName();
        uint GetCpuFrequency();
        float GetCpuUsage();
        int GetQtyCore();
    }
}
