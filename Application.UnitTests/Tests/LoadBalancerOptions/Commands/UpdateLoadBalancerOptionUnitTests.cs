using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.CQRS.Ocelot.LoadBalancerOptions.Commands.UpdateLoadBalancerOption;
using Application.UnitTests.Common;
using Xunit;

namespace Application.UnitTests.Tests.LoadBalancerOptions.Commands
{
    public class UpdateLoadBalancerOptionUnitTests : TestBase
    {
        private readonly UpdateLoadBalancerOptionCommand.Handler _handler;

        public UpdateLoadBalancerOptionUnitTests()
        {
            _handler = new UpdateLoadBalancerOptionCommand.Handler(Context);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int updatedId = 13;
            var command = new UpdateLoadBalancerOptionCommand {LoadBalancerOptionId = updatedId, RouteId = 30};

            //Act
            await _handler.Handle(command, CancellationToken.None);
            var unit = await Context.LoadBalancerOptions.FindAsync(updatedId);

            //Assert
            Assert.NotNull(unit);
            Assert.Equal(updatedId, unit.LoadBalancerOptionId);
            Assert.Equal(30, unit.RouteId);
        }

        [Fact]
        public async Task Handle_GivenNotFoundException()
        {
            //Arrange
            const int updatedId = 50;
            var command = new UpdateLoadBalancerOptionCommand {LoadBalancerOptionId = updatedId, RouteId = 30};

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}