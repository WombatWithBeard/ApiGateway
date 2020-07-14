using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiGateway.IntegrationTests.Common;
using Application.CQRS.Ocelot.LoadBalancerOptions.Queries.GetLoadBalancerOptionsList;
using Xunit;

namespace ApiGateway.IntegrationTests.Controllers.LoadBalancerOptions
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
        public async Task ReturnsLoadBalancerOptionsListViewModel()
        {

            var response = await _client.GetAsync(UriForTests.GetAllUri(ControllerNames.LoadBalancerOptions));

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<LoadBalancerOptionsListViewModel>(response);

            Assert.IsType<LoadBalancerOptionsListViewModel>(vm);
            Assert.NotEmpty(vm.ListDtos);
        }
    }
}