using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Ocelot.Routes.Queries.GetRoutesList;
using Application.UnitTests.Common;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Application.UnitTests.Tests.Routes.Queries
{
    public class GetRoutesListUnitTests : TestBase
    {
        private readonly GetRoutesListQuery.Handler _handler;

        public GetRoutesListUnitTests()
        {
            _handler = new GetRoutesListQuery.Handler(Context, Mapper, NullLogger<GetRoutesListQuery.Handler>.Instance);
        }

        [Fact]
        public async Task Handle_GivenAllResults()
        {
            //Arrange
            var query = new GetRoutesListQuery();

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.IsType<RoutesListViewModel>(result);
        }
    }
}