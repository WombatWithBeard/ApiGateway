using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.CQRS.Ocelot.AuthenticationOptions.Commands.DeleteAuthenticationOption;
using Application.UnitTests.Common;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Application.UnitTests.Tests.AuthenticationOptions.Commands
{
    public class DeleteAuthenticationOptionUnitTests : TestBase
    {
        private readonly DeleteAuthenticationOptionCommand.Handler _handler;

        public DeleteAuthenticationOptionUnitTests()
        {
            _handler = new DeleteAuthenticationOptionCommand.Handler(Context,
                NullLogger<DeleteAuthenticationOptionCommand.Handler>.Instance);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int deleteId = 18;
            var command = new DeleteAuthenticationOptionCommand {Id = deleteId};

            //Act
            await _handler.Handle(command, CancellationToken.None);
            var unit = await Context.AuthenticationOptions.FindAsync(deleteId);

            //Assert
            Assert.Null(unit);
        }

        [Fact]
        public async Task Handle_GivenNotFoundException()
        {
            //Arrange
            const int invalidId = 40;
            var command = new DeleteAuthenticationOptionCommand {Id = invalidId};

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}