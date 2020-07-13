using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.CQRS.Ocelot.RouteClaimsRequirements.Commands.DeleteRouteClaimsRequirement;
using Application.UnitTests.Common;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Application.UnitTests.Tests.RouteClaimsRequirements.Commands
{
    public class DeleteRouteClaimsRequirementUnitTests : TestBase
    {
        private readonly DeleteRouteClaimsRequirementCommand.Handler _handler;

        public DeleteRouteClaimsRequirementUnitTests()
        {
            _handler = new DeleteRouteClaimsRequirementCommand.Handler(Context,
                NullLogger<DeleteRouteClaimsRequirementCommand.Handler>.Instance);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int deleteId = 18;
            var command = new DeleteRouteClaimsRequirementCommand {Id = deleteId};

            //Act
            await _handler.Handle(command, CancellationToken.None);
            var unit = await Context.RouteClaimsRequirements.FindAsync(deleteId);

            //Assert
            Assert.Null(unit);
        }

        [Fact]
        public async Task Handle_GivenNotFoundException()
        {
            //Arrange
            const int invalidId = 40;
            var command = new DeleteRouteClaimsRequirementCommand {Id = invalidId};

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}