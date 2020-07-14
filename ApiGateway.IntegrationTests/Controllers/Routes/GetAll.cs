using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiGateway.IntegrationTests.Common;
using Application.CQRS.Ocelot.Routes.Queries.GetRoutesList;
using Xunit;

namespace ApiGateway.IntegrationTests.Controllers.Routes
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
        public async Task ReturnsRoutesListViewModel()
        {

            var response = await _client.GetAsync(UriForTests.GetAllUri(ControllerNames.Routes));

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<RoutesListViewModel>(response);

            Assert.IsType<RoutesListViewModel>(vm);
            Assert.NotEmpty(vm.ListDtos);
        }
    }
}