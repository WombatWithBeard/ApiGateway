using System;
using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Ocelot.RouteClaimsRequirements.Commands.CreateRouteClaimsRequirement;
using Application.UnitTests.Common;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Application.UnitTests.Tests.RouteClaimsRequirements.Commands
{
    public class CreateRouteClaimsRequirementUnitTests : TestBase
    {
        private readonly CreateRouteClaimsRequirementCommand.Handler _handler;

        public CreateRouteClaimsRequirementUnitTests()
        {
            _handler = new CreateRouteClaimsRequirementCommand.Handler(Context, Mapper,
                NullLogger<CreateRouteClaimsRequirementCommand.Handler>.Instance);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int createId = 35;
            var command = new CreateRouteClaimsRequirementCommand {RouteClaimsRequirementId = createId, Role = "false"};

            //Act
            await _handler.Handle(command, CancellationToken.None);
            var unit = await Context.RouteClaimsRequirements.FindAsync(createId);

            //Assert
            Assert.Equal(createId, unit.RouteClaimsRequirementId);
            Assert.Equal("false", unit.Role);
        }

        [Fact]
        public async Task Handle_GivenInvalidOperationResult()
        {
            //Arrange
            const int createId = 10;
            var command = new CreateRouteClaimsRequirementCommand {RouteClaimsRequirementId = createId};

            //Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}