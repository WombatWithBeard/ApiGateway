using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Ocelot.DownstreamHostAndPorts.Queries.GetDownstreamHostAndPortsList;
using Application.UnitTests.Common;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Application.UnitTests.Tests.DownstreamHostAndPorts.Queries
{
    public class GetDownstreamHostAndPortsListUnitTests : TestBase
    {
        private readonly GetDownstreamHostAndPortsListQuery.Handler _handler;

        public GetDownstreamHostAndPortsListUnitTests()
        {
            _handler = new GetDownstreamHostAndPortsListQuery.Handler(Context, Mapper, NullLogger<GetDownstreamHostAndPortsListQuery.Handler>.Instance);
        }

        [Fact]
        public async Task Handle_GivenAllResults()
        {
            //Arrange
            var query = new GetDownstreamHostAndPortsListQuery();

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.IsType<DownstreamHostAndPortsListViewModel>(result);
        }
    }
}