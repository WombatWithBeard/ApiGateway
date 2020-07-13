using System.Threading;
using System.Threading.Tasks;
using Application.CQRS.Ocelot.AuthenticationOptions.Queries.GetAuthenticationOptionsList;
using Application.UnitTests.Common;
using Microsoft.Extensions.Logging.Abstractions;
using Xunit;

namespace Application.UnitTests.Tests.AuthenticationOptions.Queries
{
    public class GetAuthenticationOptionsListUnitTests : TestBase
    {
        private readonly GetAuthenticationOptionsListQuery.Handler _handler;

        public GetAuthenticationOptionsListUnitTests()
        {
            _handler = new GetAuthenticationOptionsListQuery.Handler(Context, Mapper,
                NullLogger<GetAuthenticationOptionsListQuery.Handler>.Instance);
        }

        [Fact]
        public async Task Handle_GivenAllResults()
        {
            //Arrange
            var query = new GetAuthenticationOptionsListQuery();

            //Act
            var result = await _handler.Handle(query, CancellationToken.None);

            //Assert
            Assert.IsType<AuthenticationOptionsListViewModel>(result);
        }
    }
}