using SysAgentV2.Models;

namespace SysAgentV2.Helpers.Interfaces
{
    public interface IHelper
    {
        Task<Memory> GetMemoryInfoAsync();
        Task<List<Disk>> GetInfoDiskAsync();
        Task<Cpu> GetInfoCpuAsync();
        Task<Metrics> GetHardwareInfoAsync();
    }
}
