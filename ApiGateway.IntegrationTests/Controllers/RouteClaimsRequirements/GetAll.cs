﻿using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ApiGateway.IntegrationTests.Common;
using Application.CQRS.Ocelot.RouteClaimsRequirements.Queries.GetRouteClaimsRequirementsList;
using Xunit;

namespace ApiGateway.IntegrationTests.Controllers.RouteClaimsRequirements
{
    public class GetAll : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public GetAll(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Test");
        }

        [Fact]
        public async Task ReturnsRouteClaimsRequirementsListViewModel()
        {
            var response = await _client.GetAsync(UriForTests.GetAllUri(ControllerNames.RouteClaimsRequirements));

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<RouteClaimsRequirementsListViewModel>(response);

            Assert.IsType<RouteClaimsRequirementsListViewModel>(vm);
            Assert.NotEmpty(vm.ListDtos);
        }
    }
}