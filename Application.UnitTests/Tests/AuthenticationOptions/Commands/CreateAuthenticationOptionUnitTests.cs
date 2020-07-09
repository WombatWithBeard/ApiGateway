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
            var command = new CreateAuthenticationOptionCommand {AuthenticationOptionId = 35, RouteId = 1};
            
            //Act
            var result = await _handler.Handle(command, CancellationToken.None);
            
            //Assert
            
        }
    }
}