﻿using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiGateway.IntegrationTests.Common;
using Application.CQRS.Ocelot.GlobalConfigurations.Queries.GetGlobalConfigurationsList;
using Xunit;

namespace ApiGateway.IntegrationTests.Controllers.GlobalConfigurations
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
        public async Task ReturnsGlobalConfigurationsListViewModel()
        {

            var response = await _client.GetAsync(UriForTests.GetAllUri(ControllerNames.GlobalConfigurations));

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<GlobalConfigurationsListViewModel>(response);

            Assert.IsType<GlobalConfigurationsListViewModel>(vm);
            Assert.NotEmpty(vm.ListDtos);
        }
    }
}