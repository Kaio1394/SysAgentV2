using SysAgentV2.Models;

namespace SysAgentV2.Interfaces
{
    public interface IHelper
    {
        Task<Models.Memory> GetMemoryInfoAsync();
        Task<List<Models.Disk>> GetInfoDiskAsync();
        Task<Models.Cpu> GetInfoCpuAsync();
        Task<Metrics> GetHardwareInfoAsync();
    }
}
