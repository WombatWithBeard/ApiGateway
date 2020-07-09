using System;
using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Ocelot.AuthenticationOptions.Commands.CreateAuthenticationOption;
using Application.UnitTests.Common;
using Xunit;

namespace Application.UnitTests.Tests.AuthenticationOptions.Commands
{
    public class CreateAuthenticationOptionUnitTests : TestBase
    {
        private readonly CreateAuthenticationOptionCommand.Handler _handler;

        public CreateAuthenticationOptionUnitTests()
        {
            _handler = new CreateAuthenticationOptionCommand.Handler(Context, Mapper);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int createId = 35;
            var command = new CreateAuthenticationOptionCommand {AuthenticationOptionId = createId, RouteId = 1};
            
            //Act
            await _handler.Handle(command, CancellationToken.None);
            var unit = await Context.AuthenticationOptions.FindAsync(createId);
            
            //Assert
            Assert.Equal(createId, unit.AuthenticationOptionId);
            Assert.Equal(1, unit.RouteId);
        }

        [Fact]
        public async Task Handle_GivenInvalidOperationResult()
        {
            //Arrange
            const int createId = 10;
            var command = new CreateAuthenticationOptionCommand {AuthenticationOptionId = createId, RouteId = 1};
            
            //Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => _handler.Handle(command, CancellationToken.None));
        }
    }
}