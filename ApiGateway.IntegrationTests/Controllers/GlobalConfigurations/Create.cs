using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiGateway.IntegrationTests.Common;
using Domain.Entities.Routes;
using Xunit;

namespace ApiGateway.IntegrationTests.Controllers.GlobalConfigurations
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Test");
        }

        [Fact]
        public async Task CreateGlobalConfiguration_ReturnSuccessStatusCode()
        {
            //Arrange 
            var newUnit = new GlobalConfiguration {BaseUrl = "Test"};
            var content = Utilities.GetRequestContent(newUnit);

            //Act
            var response =
                await _client.PostAsync(UriForTests.CreateUri(ControllerNames.GlobalConfigurations), content);

            //Assert
            response.EnsureSuccessStatusCode();
        }
    }
}