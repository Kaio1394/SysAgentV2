using Moq;
using SysAgentV2.Helpers.Interfaces;
using SysAgentV2.Helpers;
using SysAgentV2.Models.Infos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysAgentV2.Repository.Interfaces;
using SysAgentV2.Data;
using Microsoft.EntityFrameworkCore;
using SysAgentV2.Models;
using SysAgentUnitTest.Mock;
using SysAgentV2.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SysAgentUnitTest.Repository
{
    public class AgentExecutionStatusRepositoryUnitTest
    {
        private Mock<ISysDbContext> _dbContext;
        private AgentExecutionStatusRepository _repository;
        private DateTime _createdAt;

        [SetUp]
        public void Setup()
        {
            DateTime.TryParse("1990-01-01", out _createdAt);
            var data = new List<AgentExecutionStatus>
            {
                new AgentExecutionStatus
                {
                    CreatedAt = _createdAt,
                    Id = 1,
                    Status = "RUNNING"
                }
            };
            var mockSet = DbSetMockHelper.CreateMockSet<AgentExecutionStatus>(data);

            _dbContext = new Mock<ISysDbContext>();
            _dbContext.Setup(x => x.AgentStatus).Returns(mockSet.Object);
            _dbContext.Setup(d => d.SaveChangesAsync(It.IsAny<CancellationToken>())).ReturnsAsync(1);
            _repository = new AgentExecutionStatusRepository(_dbContext.Object);
        }
        [Test]
        public async Task GetByIdAsync_ShouldReturnData()
        {
            var result = await _repository.GetByIdAsync(1);
            Assert.That(result, Is.Not.Null);
            Assert.That(result.Id == 1);
            Assert.That(result.Status == "RUNNING");
            Assert.That(result.CreatedAt == _createdAt);
        }
    }
}
