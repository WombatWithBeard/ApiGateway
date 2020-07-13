using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.CQRS.Ocelot.LoadBalancerOptions.Commands.DeleteLoadBalancerOption;
using Application.UnitTests.Common;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Application.UnitTests.Tests.LoadBalancerOptions.Commands
{
    public class DeleteLoadBalancerOptionUnitTests: TestBase
    {
        private readonly DeleteLoadBalancerOptionCommand.Handler _handler;

        public DeleteLoadBalancerOptionUnitTests()
        {
            _handler = new DeleteLoadBalancerOptionCommand.Handler(Context, NullLogger<DeleteLoadBalancerOptionCommand.Handler>.Instance);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int deleteId = 18;
            var command = new DeleteLoadBalancerOptionCommand {Id = deleteId};

            //Act
            await _handler.Handle(command, CancellationToken.None);
            var unit = await Context.LoadBalancerOptions.FindAsync(deleteId);

            //Assert
            Assert.Null(unit);
        }

        [Fact]
        public async Task Handle_GivenNotFoundException()
        {
            //Arrange
            const int invalidId = 40;
            var command = new DeleteLoadBalancerOptionCommand {Id = invalidId};

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}