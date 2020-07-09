using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.CQRS.Ocelot.GlobalConfigurations.Commands.UpdateGlobalConfiguration;
using Application.UnitTests.Common;
using Xunit;

namespace Application.UnitTests.Tests.GlobalConfigurations.Commands
{
    public class UpdateGlobalConfigurationUnitTests : TestBase
    {
        private readonly UpdateGlobalConfigurationCommand.Handler _handler;

        public UpdateGlobalConfigurationUnitTests()
        {
            _handler = new UpdateGlobalConfigurationCommand.Handler(Context);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int updatedId = 13;
            var command = new UpdateGlobalConfigurationCommand {GlobalConfigurationId = updatedId, BaseUrl = "test"};

            //Act
            await _handler.Handle(command, CancellationToken.None);
            var unit = await Context.GlobalConfigurations.FindAsync(updatedId);

            //Assert
            Assert.NotNull(unit);
            Assert.Equal(updatedId, unit.GlobalConfigurationId);
            Assert.Equal("test", unit.BaseUrl);
        }

        [Fact]
        public async Task Handle_GivenNotFoundException()
        {
            //Arrange
            const int updatedId = 50;
            var command = new UpdateGlobalConfigurationCommand {GlobalConfigurationId = updatedId};

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}