using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.CQRS.Ocelot.DownstreamHostAndPorts.Commands.DeleteDownstreamHostAndPort;
using Application.UnitTests.Common;
using Xunit;

namespace Application.UnitTests.Tests.DownstreamHostAndPorts.Commands
{
    public class DeleteDownstreamHostAndPortUnitTests : TestBase
    {
        private readonly DeleteDownstreamHostAndPortCommand.Handler _handler;

        public DeleteDownstreamHostAndPortUnitTests()
        {
            _handler = new DeleteDownstreamHostAndPortCommand.Handler(Context);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int deleteId = 18;
            var command = new DeleteDownstreamHostAndPortCommand {Id = deleteId};

            //Act
            await _handler.Handle(command, CancellationToken.None);
            var unit = await Context.DownstreamHostAndPorts.FindAsync(deleteId);

            //Assert
            Assert.Null(unit);
        }

        [Fact]
        public async Task Handle_GivenNotFoundException()
        {
            //Arrange
            const int invalidId = 40;
            var command = new DeleteDownstreamHostAndPortCommand {Id = invalidId};

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}