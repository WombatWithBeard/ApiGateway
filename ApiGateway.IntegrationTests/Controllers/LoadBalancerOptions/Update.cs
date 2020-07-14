using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiGateway.IntegrationTests.Common;
using Domain.Entities.Routes;
using Xunit;

namespace ApiGateway.IntegrationTests.Controllers.LoadBalancerOptions
{
    public class Update : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Update(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Test");
        }

        [Fact]
        public async Task UpdateLoadBalancerOption_ReturnSuccessStatusCode()
        {
            //Arrange 
            var newUnit = new LoadBalancerOption {Type = "Test10", LoadBalancerOptionId = 10};
            var content = Utilities.GetRequestContent(newUnit);

            //Act
            var response =
                await _client.PutAsync(UriForTests.UpdateUri(ControllerNames.LoadBalancerOptions), content);

            //Assert
            response.EnsureSuccessStatusCode();
        }
        
        [Fact]
        public async Task UpdateLoadBalancerOption_ReturnsNotFoundStatusCode()
        {
            //Arrange 
            var newUnit = new LoadBalancerOption {Type = "Test10", LoadBalancerOptionId = 80};
            var content = Utilities.GetRequestContent(newUnit);

            //Act
            var response =
                await _client.PutAsync(UriForTests.UpdateUri(ControllerNames.LoadBalancerOptions), content);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}