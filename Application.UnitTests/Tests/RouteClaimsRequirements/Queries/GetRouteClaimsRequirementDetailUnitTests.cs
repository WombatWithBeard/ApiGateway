using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.CQRS.Ocelot.RouteClaimsRequirements.Queries.GetRouteClaimsRequirement;
using Application.CQRS.Ocelot.Routes.Queries.GetRoute;
using Application.UnitTests.Common;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Application.UnitTests.Tests.RouteClaimsRequirements.Queries
{
    public class GetRouteClaimsRequirementDetailUnitTests : TestBase
    {
        private readonly GetRouteClaimsRequirementDetailQuery.Handler _handler;

        public GetRouteClaimsRequirementDetailUnitTests()
        {
            _handler = new GetRouteClaimsRequirementDetailQuery.Handler(Context, Mapper,
                NullLogger<GetRouteClaimsRequirementDetailQuery.Handler>.Instance);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int validId = 10;
            var query = new GetRouteClaimsRequirementDetailQuery {Id = validId};

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.NotNull(result.Dto);
            Assert.IsType<RouteClaimsRequirementDetailViewModel>(result);
            Assert.True(result.Success);
        }

        [Fact]
        public async Task Handle_GivenNotFoundException()
        {
            //Arrange
            const int validId = 50;
            var query = new GetRouteClaimsRequirementDetailQuery {Id = validId};

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(query, CancellationToken.None));
        }
    }
}