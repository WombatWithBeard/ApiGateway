using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.CQRS.Ocelot.GlobalConfigurations.Commands.DeleteGlobalConfiguration;
using Application.UnitTests.Common;
using Xunit;

namespace Application.UnitTests.Tests.GlobalConfigurations.Commands
{
    public class DeleteGlobalConfigurationUnitTests : TestBase
    {
        private readonly DeleteGlobalConfigurationCommand.Handler _handler;

        public DeleteGlobalConfigurationUnitTests()
        {
            _handler = new DeleteGlobalConfigurationCommand.Handler(Context);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int deleteId = 18;
            var command = new DeleteGlobalConfigurationCommand {Id = deleteId};

            //Act
            await _handler.Handle(command, CancellationToken.None);
            var unit = await Context.GlobalConfigurations.FindAsync(deleteId);

            //Assert
            Assert.Null(unit);
        }

        [Fact]
        public async Task Handle_GivenNotFoundException()
        {
            //Arrange
            const int invalidId = 40;
            var command = new DeleteGlobalConfigurationCommand {Id = invalidId};

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}