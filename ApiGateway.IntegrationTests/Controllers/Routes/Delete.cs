using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ApiGateway.IntegrationTests.Common;
using Xunit;

namespace ApiGateway.IntegrationTests.Controllers.Routes
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
            var validId = 15;

            var response =
                await _client.DeleteAsync(UriForTests.DeleteUri(ControllerNames.Routes, validId));

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidId_ReturnsNotFoundStatusCode()
        {
            var invalidId = 50;

            var response =
                await _client.DeleteAsync(UriForTests.DeleteUri(ControllerNames.Routes, invalidId));

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}