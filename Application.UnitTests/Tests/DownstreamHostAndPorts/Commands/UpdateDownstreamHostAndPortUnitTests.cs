using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.CQRS.Ocelot.DownstreamHostAndPorts.Commands.UpdateDownstreamHostAndPort;
using Application.UnitTests.Common;
using Xunit;

namespace Application.UnitTests.Tests.DownstreamHostAndPorts.Commands
{
    public class UpdateDownstreamHostAndPortUnitTests : TestBase
    {
        private readonly UpdateDownstreamHostAndPortCommand.Handler _handler;

        public UpdateDownstreamHostAndPortUnitTests()
        {
            _handler = new UpdateDownstreamHostAndPortCommand.Handler(Context);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int updatedId = 13;
            var command = new UpdateDownstreamHostAndPortCommand {DownstreamHostAndPortId = updatedId, RouteId = 30};

            //Act
            await _handler.Handle(command, CancellationToken.None);
            var unit = await Context.DownstreamHostAndPorts.FindAsync(updatedId);

            //Assert
            Assert.NotNull(unit);
            Assert.Equal(updatedId, unit.DownstreamHostAndPortId);
            Assert.Equal(30, unit.RouteId);
        }

        [Fact]
        public async Task Handle_GivenNotFoundException()
        {
            //Arrange
            const int updatedId = 50;
            var command = new UpdateDownstreamHostAndPortCommand {DownstreamHostAndPortId = updatedId, RouteId = 30};

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}