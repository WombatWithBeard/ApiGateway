using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiGateway.IntegrationTests.Common;
using Application.CQRS.Ocelot.Routes.Queries.GetRoute;
using Xunit;

namespace ApiGateway.IntegrationTests.Controllers.Routes
{
    public class Get : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Get(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Test");
        }

        [Fact]
        public async Task GivenId_ReturnsRouteViewModel()
        {
            var id = 10;

            var response = await _client.GetAsync(UriForTests.GetUri(ControllerNames.Routes, id));

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<RouteDetailViewModel>(response);

            Assert.Equal(id, vm.Dto.RouteId);
        }

        [Fact]
        public async Task GivenInvalidId_ReturnsNotFoundStatusCode()
        {
            var invalidId = 100;

            var response = await _client.GetAsync(UriForTests.GetUri(ControllerNames.Routes, invalidId));

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}