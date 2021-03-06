﻿using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiGateway.IntegrationTests.Common;
using Application.CQRS.Ocelot.DownstreamHostAndPorts.Queries.GetDownstreamHostAndPortsList;
using Xunit;

namespace ApiGateway.IntegrationTests.Controllers.DownstreamHostAndPorts
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
        public async Task ReturnsDownstreamHostAndPortsListViewModel()
        {

            var response = await _client.GetAsync(UriForTests.GetAllUri(ControllerNames.DownstreamHostAndPorts));

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<DownstreamHostAndPortsListViewModel>(response);

            Assert.IsType<DownstreamHostAndPortsListViewModel>(vm);
            Assert.NotEmpty(vm.ListDtos);
        }
    }
}