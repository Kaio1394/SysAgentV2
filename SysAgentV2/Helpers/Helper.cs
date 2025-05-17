using Hardware.Info;
using SysAgentV2.Interfaces;
using SysAgentV2.Models;
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
        public Task<float> GetCpuUsageAsync()
        {
            return Task.Run(() =>
            {
                var usage =  _hardwareInfo.GetCpuUsage();
                return usage;
            });
        }
        public Task<uint> GetCpuFrequencyAsync()
        {
            return Task.Run(() =>
            {
                var freq = _hardwareInfo.GetCpuFrequency();
                return freq;
            });
        }
        public Task<int> GetQtyCoreAsync()
        {
            return Task.Run(() =>
            {
                var qtyCore = _hardwareInfo.GetQtyCore();
                return qtyCore;
            });
        }
        public Task<string> GetNameProcessorAsync()
        {
            return Task.Run(() =>
            {
                var nameProcessor = _hardwareInfo.GetProcessorName();
                return nameProcessor;
            });  
        }
    }
}
