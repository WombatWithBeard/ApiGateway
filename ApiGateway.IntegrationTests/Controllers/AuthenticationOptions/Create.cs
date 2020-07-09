using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using ApiGateway.IntegrationTests.Common;
using Domain.Entities.Routes;
using Xunit;

namespace ApiGateway.IntegrationTests.Controllers.AuthenticationOptions
{
    public class Create : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public Create(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async Task CreateRequest_ReturnSuccessStatusCode()
        {
            //Arrange 
            var newUnit = new AuthenticationOption {AuthenticationProviderKey = "Test"};
            var content = Utilities.GetRequestContent(newUnit);

            //Act
            var response = await _client.PostAsync(UriForTests.CreateUri(ControllerNames.AuthenticationOptions), content);

            //Assert
            response.EnsureSuccessStatusCode();
        }
    }
}