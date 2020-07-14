using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiGateway.IntegrationTests.Common;
using Application.CQRS.Ocelot.AuthenticationOptions.Queries.GetAuthenticationOptionsList;
using Xunit;

namespace ApiGateway.IntegrationTests.Controllers.AuthenticationOptions
{
    public class GetAll: IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public GetAll(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Test");
        }
        
        [Fact]
        public async Task ReturnsAuthenticationOptionsListViewModel()
        {

            var response = await _client.GetAsync(UriForTests.GetAllUri(ControllerNames.AuthenticationOptions));

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<AuthenticationOptionsListViewModel>(response);

            Assert.IsType<AuthenticationOptionsListViewModel>(vm);
            Assert.NotEmpty(vm.ListDtos);
        }
    }
}