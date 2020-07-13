using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Ocelot.RouteClaimsRequirements.Queries.GetRouteClaimsRequirementsList;
using Application.CQRS.Ocelot.Routes.Queries.GetRoutesList;
using Application.UnitTests.Common;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Application.UnitTests.Tests.RouteClaimsRequirements.Queries
{
    public class GetRouteClaimsRequirementsListUnitTests : TestBase
    {
        private readonly GetRouteClaimsRequirementsListQuery.Handler _handler;

        public GetRouteClaimsRequirementsListUnitTests()
        {
            _handler = new GetRouteClaimsRequirementsListQuery.Handler(Context, Mapper,
                NullLogger<GetRouteClaimsRequirementsListQuery.Handler>.Instance);
        }

        [Fact]
        public async Task Handle_GivenAllResults()
        {
            //Arrange
            var query = new GetRouteClaimsRequirementsListQuery();

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.IsType<RouteClaimsRequirementsListViewModel>(result);
        }
    }
}