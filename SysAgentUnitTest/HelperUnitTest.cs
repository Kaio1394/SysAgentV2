using Moq;
using SysAgentV2.Helpers;
using SysAgentV2.Interfaces;

namespace SysAgentUnitTest
{
    public class HelperUnitTest
    {
        private Helper _helper;
        private Mock<IAgentHardwareInfo> _mockHardwareInfo;
        const uint CPU_USAGE = 80;
        const string PROCESSOR_NAME = "Test Processor Name";
        const int QTY_CORE = 12;

        [SetUp]
        public void Setup()
        {
            _mockHardwareInfo = new Mock<IAgentHardwareInfo>();
            _mockHardwareInfo.Setup(x => x.GetProcessorName()).Returns(PROCESSOR_NAME);
            _mockHardwareInfo.Setup(x => x.GetCpuFrequency()).Returns(12);
            _mockHardwareInfo.Setup(x => x.GetCpuUsage()).Returns(CPU_USAGE);
            _mockHardwareInfo.Setup(x => x.GetQtyCore()).Returns(QTY_CORE);
        }

        //[Test]
        //public async Task GetNameProcessor_WhenCalled_ReturnsProcessorName()
        //{         
        //    _helper = new Helper(_mockHardwareInfo.Object);
        //    var result = await _helper.GetNameProcessorAsync();
        //    Assert.AreEqual(result, PROCESSOR_NAME);
        //}
        //[Test]
        //public async Task GetGetCpuUsage_WhenCalled_ReturnsCpuUsage()
        //{
        //    _helper = new Helper(_mockHardwareInfo.Object);
        //    var result = await _helper.GetCpuUsageAsync();
        //    Assert.AreEqual(result, CPU_USAGE);
        //}
        //[Test]
        //public async Task GetGetQtyCore_WhenCalled_ReturnsQtyCore()
        //{
        //    _helper = new Helper(_mockHardwareInfo.Object);
        //    var result = await _helper.GetQtyCoreAsync();
        //    Assert.AreEqual(result, QTY_CORE);
        //}
    }
}