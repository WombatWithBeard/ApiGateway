﻿using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ApiGateway.IntegrationTests.Common;
using Application.CQRS.Ocelot.RouteClaimsRequirements.Queries.GetRouteClaimsRequirement;
using Application.CQRS.Ocelot.Routes.Queries.GetRoute;
using Xunit;

namespace ApiGateway.IntegrationTests.Controllers.RouteClaimsRequirements
{
    public class Get : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private HttpClient _client;

        public Get(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task GivenId_ReturnsRouteClaimsRequirementViewModel()
        {
            var id = 10;

            var response = await _client.GetAsync(UriForTests.GetUri(ControllerNames.RouteClaimsRequirements, id));

            response.EnsureSuccessStatusCode();

            var vm = await Utilities.GetResponseContent<RouteClaimsRequirementDetailViewModel>(response);

            Assert.Equal(id, vm.Dto.RouteId);
        }

        [Fact]
        public async Task GivenInvalidId_ReturnsNotFoundStatusCode()
        {
            var invalidId = 100;

            var response = await _client.GetAsync(UriForTests.GetUri(ControllerNames.RouteClaimsRequirements, invalidId));

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}