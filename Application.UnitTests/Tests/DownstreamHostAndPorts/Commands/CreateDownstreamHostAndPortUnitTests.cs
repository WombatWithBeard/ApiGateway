using System;
using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Ocelot.DownstreamHostAndPorts.Commands.CreateDownstreamHostAndPort;
using Application.UnitTests.Common;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Application.UnitTests.Tests.DownstreamHostAndPorts.Commands
{
    public class CreateDownstreamHostAndPortUnitTests : TestBase
    {
        private readonly CreateDownstreamHostAndPortCommand.Handler _handler;

        public CreateDownstreamHostAndPortUnitTests()
        {
            _handler = new CreateDownstreamHostAndPortCommand.Handler(Context, Mapper, NullLogger<CreateDownstreamHostAndPortCommand.Handler>.Instance);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int createId = 35;
            var command = new CreateDownstreamHostAndPortCommand {DownstreamHostAndPortId = createId, RouteId = 1};

            //Act
            await _handler.Handle(command, CancellationToken.None);
            var unit = await Context.DownstreamHostAndPorts.FindAsync(createId);

            //Assert
            Assert.Equal(createId, unit.DownstreamHostAndPortId);
            Assert.Equal(1, unit.RouteId);
        }

        [Fact]
        public async Task Handle_GivenInvalidOperationResult()
        {
            //Arrange
            const int createId = 10;
            var command = new CreateDownstreamHostAndPortCommand {DownstreamHostAndPortId = createId, RouteId = 1};

            //Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}