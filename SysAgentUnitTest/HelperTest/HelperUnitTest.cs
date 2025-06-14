using Moq;
using SysAgentV2.Helpers;
using SysAgentV2.Helpers.Interfaces;
using SysAgentV2.Models.Infos;

namespace SysAgentUnitTest.HelperTest
{
    public class HelperUnitTest
    {
        private Helper _helper;
        private Mock<IAgentHardwareInfo> _mockHardwareInfo;
        const uint CPU_USAGE = 80;
        const string MEM_FREE = "1500 MB";
        const string MEM_TOTAL = "3500 MB";
        const string MEM_USAGE = "3500 MB";
        const long DISK_FREE_SPACE = 350;
        const long DISK_TOTAL_SPACE = 1000;
        const string PROCESSOR_NAME = "Test Processor Name";
        const int QTY_CORE = 12;

        [SetUp]
        public void Setup()
        {
            _mockHardwareInfo = new Mock<IAgentHardwareInfo>();
            _mockHardwareInfo.Setup(h => h.GetInfoCpu()).Returns(new Cpu { UsagePercent = CPU_USAGE });
            _mockHardwareInfo.Setup(h => h.GetInfoMemory()).Returns(new Memory { Free = MEM_FREE, Total = MEM_TOTAL, Usage = MEM_USAGE });
            _mockHardwareInfo.Setup(h => h.GetInfoDisk()).Returns(new List<Disk>
            {
                new Disk
                {
                    Name = "C://",
                    Info = new DictionaryInfoDisk
                    {
                        FreeSpace = DISK_FREE_SPACE,
                        TotalSpace = DISK_TOTAL_SPACE,
                        UsedSpace = DISK_TOTAL_SPACE - DISK_FREE_SPACE
                    }
                }
            });
            _helper = new Helper(_mockHardwareInfo.Object);
        }

        [Test]
        public async Task GetCpuUsage_WhenCalled_ReturnsCpuUsage()
        {
            var result = await _helper.GetInfoCpuAsync();
            Assert.IsNotNull(result);
            Assert.AreEqual(CPU_USAGE, result.UsagePercent);
        }
        [Test]
        public async Task GetMemory_WhenCalled_ReturnsMemoryFree()
        {
            var result = await _helper.GetMemoryInfoAsync();
            Assert.IsNotNull(result);
            Assert.AreEqual(MEM_FREE, result.Free);
            Assert.AreEqual(MEM_TOTAL, result.Total);
            Assert.AreEqual(MEM_USAGE, result.Usage);
        }
        [Test]
        public async Task GetDiskInfo_WhenCalled_ReturnsListDiskInfo()
        {
            List<Disk>? result = await _helper.GetInfoDiskAsync();
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
            Assert.AreEqual(result[0].Info.FreeSpace, DISK_FREE_SPACE);
            Assert.AreEqual(result[0].Info.TotalSpace, DISK_TOTAL_SPACE);
            Assert.AreEqual(result[0].Info.UsedSpace, DISK_TOTAL_SPACE - DISK_FREE_SPACE);
        }
    }
}