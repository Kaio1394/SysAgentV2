using Moq;
using SysAgentUnitTest.Repository;
using SysAgentV2.Models.Infos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysAgentV2.Services;
using SysAgentV2.Repository.Interfaces;
using NuGet.Protocol.Core.Types;
using SysAgentV2.Models.Scripts;
using SysAgentUnitTest.Mock;
using NuGet.ContentModel;

namespace SysAgentUnitTest.Service
{
    public class ScriptCmdServiceUnitTest
    {
        private Mock<IScriptCmdRepository> _repository;
        private ScriptCmdService _service; 

        [SetUp]
        public void Setup()
        {
            _repository = new Mock<IScriptCmdRepository>();

            _repository.Setup(x => x.GetAllScriptsAsync()).ReturnsAsync(
                new List<ScriptCmd>
                {
                    new ScriptCmd
                    {
                        CreatedAt = DateTime.Now,
                        Description = "Test",
                        Script = "echo Teste",
                        Tag = "Test",
                        Uuid = ConstantsMock.GuidString
                    }
                }
            );
            _repository.Setup(x => x.GetScriptCmdByUuidAsync(It.IsAny<string>())).ReturnsAsync(
                new ScriptCmd
                {
                    CreatedAt = DateTime.Now,
                    Description = "Test",
                    Script = "echo Teste",
                    Tag = "Test",
                    Uuid = ConstantsMock.GuidString
                }
            );
            _service = new ScriptCmdService(_repository.Object);
        }

        [Test]
        public async Task GetAllScripts_ReturnAllScriptCmd()
        {
            var listScripts = await _service.GetAllScripts();
            Assert.That(listScripts, Is.Not.Null);
            Assert.IsTrue(listScripts.Any());
        }

        [Test]
        public async Task GetScriptCmdByUuid_ReturnScriptCmd()
        {
            var scriptCmd = await _service.GetScriptCmdByUuid(It.IsAny<string>());
            Assert.That(scriptCmd, Is.Not.Null);
        }
    }
}
