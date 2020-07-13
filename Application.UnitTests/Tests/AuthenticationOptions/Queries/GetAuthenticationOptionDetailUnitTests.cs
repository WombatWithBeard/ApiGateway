using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.CQRS.Ocelot.AuthenticationOptions.Queries.GetAuthenticationOption;
using Application.UnitTests.Common;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Application.UnitTests.Tests.AuthenticationOptions.Queries
{
    public class GetAuthenticationOptionDetailUnitTests : TestBase
    {
        private readonly GetAuthenticationOptionDetailQuery.Handler _handler;

        public GetAuthenticationOptionDetailUnitTests()
        {
            _handler = new GetAuthenticationOptionDetailQuery.Handler(Context, Mapper,
                NullLogger<GetAuthenticationOptionDetailQuery.Handler>.Instance);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int validId = 10;
            var query = new GetAuthenticationOptionDetailQuery {Id = validId};

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.NotNull(result.Dto);
            Assert.IsType<AuthenticationOptionDetailViewModel>(result);
            Assert.True(result.Success);
        }

        [Fact]
        public async Task Handle_GivenNotFoundException()
        {
            //Arrange
            const int validId = 50;
            var query = new GetAuthenticationOptionDetailQuery {Id = validId};

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(query, CancellationToken.None));
        }
    }
}