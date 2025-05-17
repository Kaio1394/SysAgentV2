using Moq;
using SysAgentV2.Helpers;
using SysAgentV2.Interfaces;

namespace SysAgentUnitTest
{
    public class HelperUnitTest
    {
        private Helper _helper;
        private Mock<IAgentHardwareInfo> _mockHardwareInfo;

        [SetUp]
        public void Setup()
        {
            _mockHardwareInfo = new Mock<IAgentHardwareInfo>();
        }

        [Test]
        public async Task GetNameProcessorAsyncValidNameProcessor()
        {
            _mockHardwareInfo.Setup(x => x.GetProcessorName()).Returns("Test Processor Name");
            _mockHardwareInfo.Setup(x => x.GetCpuFrequency()).Returns(12);
            _mockHardwareInfo.Setup(x => x.GetCpuUsage()).Returns(80);
            _mockHardwareInfo.Setup(x => x.GetQtyCore()).Returns(12);
            _helper = new Helper(_mockHardwareInfo.Object);
            var result = await _helper.GetNameProcessorAsync();
            Assert.AreEqual(result, "Test Processor Name");
        }
    }
}