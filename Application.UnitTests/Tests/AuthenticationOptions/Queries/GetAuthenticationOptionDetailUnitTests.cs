using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Ocelot.AuthenticationOptions.Queries.GetAuthenticationOption;
using Application.UnitTests.Common;
using Xunit;

namespace Application.UnitTests.Tests.AuthenticationOptions.Queries
{
    public class GetAuthenticationOptionDetailUnitTests : TestBase
    {
        private readonly GetAuthenticationOptionDetailQuery.Handler _handler;

        public GetAuthenticationOptionDetailUnitTests()
        {
            _handler = new GetAuthenticationOptionDetailQuery.Handler(Context, Mapper);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int validId = 1;
            var query = new GetAuthenticationOptionDetailQuery{Id = validId};

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);
            
            //Assert
            Assert.NotNull(result.Dto);
        }
    }
}