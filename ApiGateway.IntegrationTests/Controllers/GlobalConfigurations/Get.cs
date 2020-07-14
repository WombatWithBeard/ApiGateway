using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiGateway.IntegrationTests.Common;
using Application.CQRS.Ocelot.GlobalConfigurations.Queries.GetGlobalConfiguration;
using Xunit;

namespace ApiGateway.IntegrationTests.Controllers.GlobalConfigurations
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
        public async Task GivenId_ReturnsGlobalConfigurationViewModel()
        {
            var id = 10;

            var response = await _client.GetAsync(UriForTests.GetUri(ControllerNames.GlobalConfigurations, id));

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<GlobalConfigurationDetailViewModel>(response);

            Assert.Equal(id, vm.Dto.GlobalConfigurationId);
        }

        [Fact]
        public async Task GivenInvalidId_ReturnsNotFoundStatusCode()
        {
            var invalidId = 100;

            var response = await _client.GetAsync(UriForTests.GetUri(ControllerNames.GlobalConfigurations, invalidId));

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}