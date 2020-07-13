using System;
using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Ocelot.LoadBalancerOptions.Commands.CreateLoadBalancerOption;
using Application.UnitTests.Common;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Application.UnitTests.Tests.LoadBalancerOptions.Commands
{
    public class CreateLoadBalancerOptionUnitTests : TestBase
    {
        private readonly CreateLoadBalancerOptionCommand.Handler _handler;

        public CreateLoadBalancerOptionUnitTests()
        {
            _handler = new CreateLoadBalancerOptionCommand.Handler(Context, Mapper, NullLogger<CreateLoadBalancerOptionCommand.Handler>.Instance);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int createId = 35;
            var command = new CreateLoadBalancerOptionCommand {LoadBalancerOptionId = createId, RouteId = 1};

            //Act
            await _handler.Handle(command, CancellationToken.None);
            var unit = await Context.LoadBalancerOptions.FindAsync(createId);

            //Assert
            Assert.Equal(createId, unit.LoadBalancerOptionId);
            Assert.Equal(1, unit.RouteId);
        }

        [Fact]
        public async Task Handle_GivenInvalidOperationResult()
        {
            //Arrange
            const int createId = 10;
            var command = new CreateLoadBalancerOptionCommand {LoadBalancerOptionId = createId, RouteId = 1};

            //Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}