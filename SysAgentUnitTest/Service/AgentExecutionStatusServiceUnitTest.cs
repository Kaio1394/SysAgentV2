using AutoMapper;
using Humanizer;
using Moq;
using NuGet.Protocol.Core.Types;
using SysAgentV2.DTOs;
using SysAgentV2.Enum;
using SysAgentV2.Models;
using SysAgentV2.Models.Infos;
using SysAgentV2.Repository.Interfaces;
using SysAgentV2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysAgentUnitTest.Service
{
    public class AgentExecutionStatusServiceUnitTest
    {
        private Mock<IAgentExecutionStatusRepository> _repository;
        private Mock<IMapper> _mapper;
        private AgentExecutionStatusService _service;
        private AgentExecutionStatus _model;
        private AgentExecutionStatusDto _modelDto;

        [SetUp]
        public void Setup()
        {
            _model = new AgentExecutionStatus
            {
                Id = 1,
                Status = ExecutionStatus.RUNNING.ToString(),
                CreatedAt = DateTime.UtcNow
            };

            _modelDto = new AgentExecutionStatusDto
            {
                Status = ExecutionStatus.STOPPED.ToString(),
                CreatedAt = _model.CreatedAt
            };

            _repository = new Mock<IAgentExecutionStatusRepository>();
            _repository.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(
                _model
            );
            _mapper = new Mock<IMapper>();
            _mapper.Setup(x => x.Map<AgentExecutionStatusDto>(_model)).Returns(_modelDto);
            _service = new AgentExecutionStatusService(_repository.Object, _mapper.Object);
        }

        [Test]
        public async Task GetByIdAsync_ReturnData()
        {
            var result = await _service.GetStatusAsync();
            Assert.IsNotNull(result);
            Assert.AreEqual(_modelDto.Status, result.Status);
        }
    }
}
