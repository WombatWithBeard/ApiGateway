using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.CQRS.Ocelot.DownstreamHostAndPorts.Queries.GetDownstreamHostAndPort;
using Application.UnitTests.Common;
using Xunit;

namespace Application.UnitTests.Tests.DownstreamHostAndPorts.Queries
{
    public class GetDownstreamHostAndPortDetailUnitTests : TestBase
    {
        private readonly GetDownstreamHostAndPortDetailQuery.Handler _handler;

        public GetDownstreamHostAndPortDetailUnitTests()
        {
            _handler = new GetDownstreamHostAndPortDetailQuery.Handler(Context, Mapper);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int validId = 10;
            var query = new GetDownstreamHostAndPortDetailQuery {Id = validId};

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.NotNull(result.Dto);
            Assert.IsType<DownstreamHostAndPortDetailViewModel>(result);
            Assert.True(result.Success);
        }

        [Fact]
        public async Task Handle_GivenNotFoundException()
        {
            //Arrange
            const int validId = 50;
            var query = new GetDownstreamHostAndPortDetailQuery {Id = validId};

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(query, CancellationToken.None));
        }
    }
}