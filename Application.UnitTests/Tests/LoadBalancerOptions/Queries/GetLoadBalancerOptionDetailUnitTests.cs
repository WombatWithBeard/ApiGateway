using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.CQRS.Ocelot.LoadBalancerOptions.Queries.GetLoadBalancerOption;
using Application.UnitTests.Common;
using Xunit;

namespace Application.UnitTests.Tests.LoadBalancerOptions.Queries
{
    public class GetLoadBalancerOptionDetailUnitTests : TestBase
    {
        private readonly GetLoadBalancerOptionDetailQuery.Handler _handler;

        public GetLoadBalancerOptionDetailUnitTests()
        {
            _handler = new GetLoadBalancerOptionDetailQuery.Handler(Context, Mapper);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int validId = 10;
            var query = new GetLoadBalancerOptionDetailQuery {Id = validId};

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.NotNull(result.Dto);
            Assert.IsType<LoadBalancerOptionDetailViewModel>(result);
            Assert.True(result.Success);
        }

        [Fact]
        public async Task Handle_GivenNotFoundException()
        {
            //Arrange
            const int validId = 50;
            var query = new GetLoadBalancerOptionDetailQuery {Id = validId};

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(query, CancellationToken.None));
        }
    }
}