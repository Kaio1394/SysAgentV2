using Moq;
using SysAgentV2.Helpers;
using SysAgentV2.Helpers.Interfaces;
using SysAgentV2.Models.Infos;

namespace SysAgentUnitTest
{
    public class HelperUnitTest
    {
        private Helper _helper;
        private Mock<IAgentHardwareInfo> _mockHardwareInfo;
        const uint CPU_USAGE = 80;
        const long FREE_SPACE = 350;
        const long TOTAL_SPACE = 1000;
        const string PROCESSOR_NAME = "Test Processor Name";
        const int QTY_CORE = 12;

        [SetUp]
        public void Setup()
        {
            _mockHardwareInfo = new Mock<IAgentHardwareInfo>();
            _mockHardwareInfo.Setup(h => h.GetInfoCpu()).Returns(new Cpu { UsagePercent = CPU_USAGE });
            _mockHardwareInfo.Setup(h => h.GetInfoDisk()).Returns(new List<Disk>
            {
                new Disk 
                { 
                    Name = "C://", 
                    Info = new DictionaryInfoDisk
                    {
                        FreeSpace = FREE_SPACE,
                        TotalSpace = TOTAL_SPACE,
                        UsedSpace = TOTAL_SPACE - FREE_SPACE
                    }
                }
            });
            _helper = new Helper(_mockHardwareInfo.Object);
        }

        [Test]
        public async Task GetGetCpuUsage_WhenCalled_ReturnsCpuUsage()
        {
            var result = await _helper.GetInfoCpuAsync();
            Assert.IsNotNull(result); 
            Assert.AreEqual(CPU_USAGE, result.UsagePercent);
        }
        [Test]
        public async Task GetDiskInfo_WhenCalled_ReturnsListDiskInfo()
        {
            List<Disk>? result = await _helper.GetInfoDiskAsync();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
            Assert.AreEqual(result[0].Info.FreeSpace, FREE_SPACE);
            Assert.AreEqual(result[0].Info.TotalSpace, TOTAL_SPACE);
            Assert.AreEqual(result[0].Info.UsedSpace, TOTAL_SPACE - FREE_SPACE);
        }
    }
}