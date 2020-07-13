using System.Net.Http;
using System.Threading.Tasks;
using ApiGateway.IntegrationTests.Common;
using Domain.Entities.Routes;
using Xunit;

namespace ApiGateway.IntegrationTests.Controllers.RouteClaimsRequirements
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateRouteClaimsRequirement_ReturnSuccessStatusCode()
        {
            //Arrange 
            var newUnit = new RouteClaimsRequirement {Role = "Test"};
            var content = Utilities.GetRequestContent(newUnit);

            //Act
            var response =
                await _client.PostAsync(UriForTests.CreateUri(ControllerNames.RouteClaimsRequirements), content);

            //Assert
            response.EnsureSuccessStatusCode();
        }
    }
}