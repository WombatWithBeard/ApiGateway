using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.CQRS.Ocelot.Routes.Queries.GetRoute;
using Application.UnitTests.Common;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Application.UnitTests.Tests.Routes.Queries
{
    public class GetRouteDetailUnitTests : TestBase
    {
        private readonly GetRouteDetailQuery.Handler _handler;

        public GetRouteDetailUnitTests()
        {
            _handler = new GetRouteDetailQuery.Handler(Context, Mapper, NullLogger<GetRouteDetailQuery.Handler>.Instance);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int validId = 10;
            var query = new GetRouteDetailQuery {Id = validId};

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.NotNull(result.Dto);
            Assert.IsType<RouteDetailViewModel>(result);
            Assert.True(result.Success);
        }

        [Fact]
        public async Task Handle_GivenNotFoundException()
        {
            //Arrange
            const int validId = 50;
            var query = new GetRouteDetailQuery {Id = validId};

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(query, CancellationToken.None));
        }
    }
}