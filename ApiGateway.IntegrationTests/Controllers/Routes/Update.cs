using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ApiGateway.IntegrationTests.Common;
using Domain.Entities.Routes;
using Xunit;

namespace ApiGateway.IntegrationTests.Controllers.Routes
{
    public class Update : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Update(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task UpdateRoute_ReturnSuccessStatusCode()
        {
            //Arrange 
            var newUnit = new Route {DownstreamScheme = "Test10", RouteId = 10};
            var content = Utilities.GetRequestContent(newUnit);

            //Act
            var response =
                await _client.PutAsync(UriForTests.UpdateUri(ControllerNames.Routes), content);

            //Assert
            response.EnsureSuccessStatusCode();
        }
        
        [Fact]
        public async Task UpdateRoute_ReturnsNotFoundStatusCode()
        {
            //Arrange 
            var newUnit = new Route {DownstreamScheme = "Test10", RouteId = 80};
            var content = Utilities.GetRequestContent(newUnit);

            //Act
            var response =
                await _client.PutAsync(UriForTests.UpdateUri(ControllerNames.Routes), content);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}