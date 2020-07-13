using System;
using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Ocelot.Routes.Commands.CreateRoute;
using Application.UnitTests.Common;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Application.UnitTests.Tests.Routes.Commands
{
    public class CreateRouteUnitTests : TestBase
    {
        private readonly CreateRouteCommand.Handler _handler;

        public CreateRouteUnitTests()
        {
            _handler = new CreateRouteCommand.Handler(Context, Mapper, NullLogger<CreateRouteCommand.Handler>.Instance);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int createId = 35;
            var command = new CreateRouteCommand {RouteId = createId, Enabled = false};

            //Act
            await _handler.Handle(command, CancellationToken.None);
            var unit = await Context.Routes.FindAsync(createId);

            //Assert
            Assert.Equal(createId, unit.RouteId);
            Assert.False(unit.Enabled);
        }

        [Fact]
        public async Task Handle_GivenInvalidOperationResult()
        {
            //Arrange
            const int createId = 10;
            var command = new CreateRouteCommand {RouteId = createId};

            //Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}