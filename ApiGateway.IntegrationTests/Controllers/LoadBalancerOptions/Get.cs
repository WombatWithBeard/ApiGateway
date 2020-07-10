using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ApiGateway.IntegrationTests.Common;
using Application.CQRS.Ocelot.LoadBalancerOptions.Queries.GetLoadBalancerOption;
using Xunit;

namespace ApiGateway.IntegrationTests.Controllers.LoadBalancerOptions
{
    public class Get : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private HttpClient _client;

        public Get(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenId_ReturnsLoadBalancerOptionViewModel()
        {
            var id = 10;

            var response = await _client.GetAsync(UriForTests.GetUri(ControllerNames.LoadBalancerOptions, id));

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<LoadBalancerOptionDetailViewModel>(response);

            Assert.Equal(id, vm.Dto.LoadBalancerOptionId);
        }

        [Fact]
        public async Task GivenInvalidId_ReturnsNotFoundStatusCode()
        {
            var invalidId = 100;

            var response = await _client.GetAsync(UriForTests.GetUri(ControllerNames.LoadBalancerOptions, invalidId));

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}