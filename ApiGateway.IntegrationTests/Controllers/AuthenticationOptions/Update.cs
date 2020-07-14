using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiGateway.IntegrationTests.Common;
using Domain.Entities.Routes;
using Xunit;

namespace ApiGateway.IntegrationTests.Controllers.AuthenticationOptions
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
        public async Task UpdateAuthenticationOption_ReturnSuccessStatusCode()
        {
            //Arrange 
            var newUnit = new AuthenticationOption {AuthenticationProviderKey = "Test10", AuthenticationOptionId = 10};
            var content = Utilities.GetRequestContent(newUnit);

            //Act
            var response =
                await _client.PutAsync(UriForTests.UpdateUri(ControllerNames.AuthenticationOptions), content);

            //Assert
            response.EnsureSuccessStatusCode();
        }
        
        [Fact]
        public async Task UpdateAuthenticationOption_ReturnsNotFoundStatusCode()
        {
            //Arrange 
            var newUnit = new AuthenticationOption {AuthenticationProviderKey = "Test10", AuthenticationOptionId = 80};
            var content = Utilities.GetRequestContent(newUnit);

            //Act
            var response =
                await _client.PutAsync(UriForTests.UpdateUri(ControllerNames.AuthenticationOptions), content);

            //Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}