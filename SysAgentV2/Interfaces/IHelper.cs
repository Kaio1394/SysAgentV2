namespace SysAgentV2.Interfaces
{
    public interface IHelper
    {
        Task<float> GetCpuUsageAsync();
        Task<int> GetQtyCoreAsync();
        Task<string> GetNameProcessorAsync();
        Task<uint> GetCpuFrequencyAsync();
    }
}
