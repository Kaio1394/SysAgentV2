using Moq;
using SysAgentUnitTest.Mock;
using SysAgentV2.Models;
using SysAgentV2.Repository.Interfaces;
using SysAgentV2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;


namespace SysAgentUnitTest.Service
{
    public class CollectMetricsServiceUnitTest
    {
        private Mock<ICollectMetricsRepository> _repository;
        private CollectMetricsService _service;
        private string _guid;
        private string _jsonResult;
        private CollectMetrics _metric;

        [SetUp]
        public void Setup()
        {
            _jsonResult = ConstantsMock.Json_Result;
            _guid = ConstantsMock.GuidString;

            _metric = new CollectMetrics()
            {
                CollectdAt = DateTime.Now,
                JsonResult = _jsonResult,
                Uuid = _guid,
            };

            IEnumerable<CollectMetrics> listMetrics = new List<CollectMetrics>() { _metric };
            _repository = new Mock<ICollectMetricsRepository>();
            _repository.Setup(x => x.GetAllMetricDataAsync()).ReturnsAsync(
                listMetrics
            );

            _repository.Setup(x => x.InsertInfoHardwareAsync(It.IsAny<CollectMetrics>())).ReturnsAsync(true);

            _service = new CollectMetricsService(_repository.Object);
        }

        [Test]
        public async Task GetAllMetricDataAsync_ReturnData()
        {
            var listData = await _service.GetAllMetricDataAsync();
            Assert.IsNotNull(listData);
            Assert.That(listData.FirstOrDefault().JsonResult.Contains(_jsonResult));
        }

        [Test]
        public async Task InsertInfoHardwareAsync_ReturnTrue()
        {
            var result = await _service.InsertInfoHardwareAsync(_metric);
            Assert.IsTrue(result);
        }
    }
}
