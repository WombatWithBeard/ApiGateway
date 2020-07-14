using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiGateway.IntegrationTests.Common;
using Xunit;

namespace ApiGateway.IntegrationTests.Controllers.LoadBalancerOptions
{
    public class Delete : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Delete(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Test");
        }

        [Fact]
        public async Task GivenId_ReturnsSuccessStatusCode()
        {
            var validId = 15;

            var response =
                await _client.DeleteAsync(UriForTests.DeleteUri(ControllerNames.LoadBalancerOptions, validId));

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task GivenInvalidId_ReturnsNotFoundStatusCode()
        {
            var invalidId = 50;

            var response =
                await _client.DeleteAsync(UriForTests.DeleteUri(ControllerNames.LoadBalancerOptions, invalidId));

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}