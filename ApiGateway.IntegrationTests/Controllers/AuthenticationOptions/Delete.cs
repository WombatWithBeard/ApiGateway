using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ApiGateway.IntegrationTests.Common;
using Xunit;

namespace ApiGateway.IntegrationTests.Controllers.AuthenticationOptions
{
    public class Delete : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private HttpClient _client;

        public Delete(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenId_ReturnsSuccessStatusCode()
        {
            var validId = 10;

            var response =
                await _client.DeleteAsync(UriForTests.DeleteUri(ControllerNames.AuthenticationOptions, validId));

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidId_ReturnsNotFoundStatusCode()
        {
            var invalidId = 50;

            var response =
                await _client.DeleteAsync(UriForTests.DeleteUri(ControllerNames.AuthenticationOptions, invalidId));

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}