using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.CQRS.Ocelot.Routes.Commands.UpdateRoute;
using Application.UnitTests.Common;
using Xunit;

namespace Application.UnitTests.Tests.Routes.Commands
{
    public class UpdateRouteUnitTests: TestBase
    {
        private readonly UpdateRouteCommand.Handler _handler;

        public UpdateRouteUnitTests()
        {
            _handler = new UpdateRouteCommand.Handler(Context);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int updatedId = 13;
            var command = new UpdateRouteCommand {RouteId = updatedId, Enabled = false};

            //Act
            await _handler.Handle(command, CancellationToken.None);
            var unit = await Context.Routes.FindAsync(updatedId);

            //Assert
            Assert.NotNull(unit);
            Assert.Equal(updatedId, unit.RouteId);
            Assert.False(unit.Enabled);
        }

        [Fact]
        public async Task Handle_GivenNotFoundException()
        {
            //Arrange
            const int updatedId = 50;
            var command = new UpdateRouteCommand {RouteId = updatedId};

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}