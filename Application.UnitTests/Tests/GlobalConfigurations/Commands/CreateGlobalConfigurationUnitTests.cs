using System;
using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Ocelot.GlobalConfigurations.Commands.CreateGlobalConfiguration;
using Application.UnitTests.Common;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Application.UnitTests.Tests.GlobalConfigurations.Commands
{
    public class CreateGlobalConfigurationUnitTests : TestBase
    {
        private readonly CreateGlobalConfigurationCommand.Handler _handler;

        public CreateGlobalConfigurationUnitTests()
        {
            _handler = new CreateGlobalConfigurationCommand.Handler(Context, Mapper, NullLogger<CreateGlobalConfigurationCommand.Handler>.Instance);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int createId = 35;
            var command = new CreateGlobalConfigurationCommand {GlobalConfigurationId = createId, BaseUrl = "test"};

            //Act
            await _handler.Handle(command, CancellationToken.None);
            var unit = await Context.GlobalConfigurations.FindAsync(createId);

            //Assert
            Assert.Equal(createId, unit.GlobalConfigurationId);
            Assert.Equal("test", unit.BaseUrl);
        }

        [Fact]
        public async Task Handle_GivenInvalidOperationResult()
        {
            //Arrange
            const int createId = 10;
            var command = new CreateGlobalConfigurationCommand {GlobalConfigurationId = createId};

            //Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}