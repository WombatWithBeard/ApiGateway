using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.CQRS.Ocelot.Routes.Commands.DeleteRoute;
using Application.UnitTests.Common;
using Xunit;

namespace Application.UnitTests.Tests.Routes.Commands
{
    public class DeleteRouteUnitTests : TestBase
    {
        private readonly DeleteRouteCommand.Handler _handler;

        public DeleteRouteUnitTests()
        {
            _handler = new DeleteRouteCommand.Handler(Context);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int deleteId = 18;
            var command = new DeleteRouteCommand {Id = deleteId};

            //Act
            await _handler.Handle(command, CancellationToken.None);
            var unit = await Context.Routes.FindAsync(deleteId);

            //Assert
            Assert.Null(unit);
        }

        [Fact]
        public async Task Handle_GivenNotFoundException()
        {
            //Arrange
            const int invalidId = 40;
            var command = new DeleteRouteCommand {Id = invalidId};

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}