using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.CQRS.Ocelot.AuthenticationOptions.Commands.UpdateAuthenticationOption;
using Application.UnitTests.Common;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Application.UnitTests.Tests.AuthenticationOptions.Commands
{
    public class UpdateAuthenticationOptionUnitTests : TestBase
    {
        private readonly UpdateAuthenticationOptionCommand.Handler _handler;

        public UpdateAuthenticationOptionUnitTests()
        {
            _handler = new UpdateAuthenticationOptionCommand.Handler(Context,
                NullLogger<UpdateAuthenticationOptionCommand.Handler>.Instance);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int updatedId = 13;
            var command = new UpdateAuthenticationOptionCommand {AuthenticationOptionId = updatedId, RouteId = 30};

            //Act
            await _handler.Handle(command, CancellationToken.None);
            var unit = await Context.AuthenticationOptions.FindAsync(updatedId);

            //Assert
            Assert.NotNull(unit);
            Assert.Equal(updatedId, unit.AuthenticationOptionId);
            Assert.Equal(30, unit.RouteId);
        }

        [Fact]
        public async Task Handle_GivenNotFoundException()
        {
            //Arrange
            const int updatedId = 50;
            var command = new UpdateAuthenticationOptionCommand {AuthenticationOptionId = updatedId, RouteId = 30};

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}