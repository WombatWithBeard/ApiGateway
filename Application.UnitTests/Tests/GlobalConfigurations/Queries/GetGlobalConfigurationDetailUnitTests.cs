using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.CQRS.Ocelot.GlobalConfigurations.Queries.GetGlobalConfiguration;
using Application.UnitTests.Common;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Application.UnitTests.Tests.GlobalConfigurations.Queries
{
    public class GetGlobalConfigurationDetailUnitTests : TestBase
    {
        private readonly GetGlobalConfigurationDetailQuery.Handler _handler;

        public GetGlobalConfigurationDetailUnitTests()
        {
            _handler = new GetGlobalConfigurationDetailQuery.Handler(Context, Mapper, NullLogger<GetGlobalConfigurationDetailQuery.Handler>.Instance);
        }

        [Fact]
        public async Task Handle_GivenValidResult()
        {
            //Arrange
            const int validId = 10;
            var query = new GetGlobalConfigurationDetailQuery {Id = validId};

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.NotNull(result.Dto);
            Assert.IsType<GlobalConfigurationDetailViewModel>(result);
            Assert.True(result.Success);
        }

        [Fact]
        public async Task Handle_GivenNotFoundException()
        {
            //Arrange
            const int validId = 50;
            var query = new GetGlobalConfigurationDetailQuery {Id = validId};

            //Assert
            await Assert.ThrowsAsync<NotFoundException>(() => _handler.Handle(query, CancellationToken.None));
        }
    }
}