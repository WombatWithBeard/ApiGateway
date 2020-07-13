using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.CQRS.Ocelot.RouteClaimsRequirements.Commands.UpdateRouteClaimsRequirement;
using Application.CQRS.Ocelot.Routes.Commands.UpdateRoute;
using Application.UnitTests.Common;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Application.UnitTests.Tests.RouteClaimsRequirements.Commands
{
    public class UpdateRouteClaimsRequirementUnitTests : TestBase
    {
        private readonly UpdateRouteClaimsRequirementCommand.Handler _handler;

        public UpdateRouteClaimsRequirementUnitTests()
        {
            _handler = new UpdateRouteClaimsRequirementCommand.Handler(Context,
                NullLogger<UpdateRouteClaimsRequirementCommand.Handler>.Instance);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int updatedId = 13;
            var command = new UpdateRouteClaimsRequirementCommand
                {RouteClaimsRequirementId = updatedId, Role = "false"};

            //Act
            await _handler.Handle(command, CancellationToken.None);
            var unit = await Context.RouteClaimsRequirements.FindAsync(updatedId);

            //Assert
            Assert.NotNull(unit);
            Assert.Equal(updatedId, unit.RouteClaimsRequirementId);
            Assert.Equal("false", unit.Role);
        }

        [Fact]
        public async Task Handle_GivenNotFoundException()
        {
            //Arrange
            const int updatedId = 50;
            var command = new UpdateRouteClaimsRequirementCommand {RouteClaimsRequirementId = updatedId};

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}