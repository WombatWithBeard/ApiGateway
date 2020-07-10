using System.Net.Http;
using System.Threading.Tasks;
using ApiGateway.IntegrationTests.Common;
using Domain.Entities.Routes;
using Xunit;

namespace ApiGateway.IntegrationTests.Controllers.LoadBalancerOptions
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateLoadBalancerOption_ReturnSuccessStatusCode()
        {
            //Arrange 
            var newUnit = new LoadBalancerOption {Type = "Test"};
            var content = Utilities.GetRequestContent(newUnit);

            //Act
            var response =
                await _client.PostAsync(UriForTests.CreateUri(ControllerNames.LoadBalancerOptions), content);

            //Assert
            response.EnsureSuccessStatusCode();
        }
    }
}