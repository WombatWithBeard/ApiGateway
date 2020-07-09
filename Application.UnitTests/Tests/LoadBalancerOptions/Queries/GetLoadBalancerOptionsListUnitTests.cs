using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Ocelot.LoadBalancerOptions.Queries.GetLoadBalancerOptionsList;
using Application.UnitTests.Common;
using Xunit;

namespace Application.UnitTests.Tests.LoadBalancerOptions.Queries
{
    public class GetLoadBalancerOptionsListUnitTests : TestBase
    {
        private readonly GetLoadBalancerOptionsListQuery.Handler _handler;

        public GetLoadBalancerOptionsListUnitTests()
        {
            _handler = new GetLoadBalancerOptionsListQuery.Handler(Context, Mapper);
        }

        [Fact]
        public async Task Handle_GivenAllResults()
        {
            //Arrange
            var query = new GetLoadBalancerOptionsListQuery();

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.IsType<LoadBalancerOptionsListViewModel>(result);
        }
    }
}