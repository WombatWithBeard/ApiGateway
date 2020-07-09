using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Ocelot.GlobalConfigurations.Queries.GetGlobalConfigurationsList;
using Application.UnitTests.Common;
using Xunit;

namespace Application.UnitTests.Tests.GlobalConfigurations.Queries
{
    public class GetGlobalConfigurationsListUnitTests : TestBase
    {
        private readonly GetGlobalConfigurationsListQuery.Handler _handler;

        public GetGlobalConfigurationsListUnitTests()
        {
            _handler = new GetGlobalConfigurationsListQuery.Handler(Context, Mapper);
        }

        [Fact]
        public async Task Handle_GivenAllResults()
        {
            //Arrange
            var query = new GetGlobalConfigurationsListQuery();

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.IsType<GlobalConfigurationsListViewModel>(result);
        }
    }
}