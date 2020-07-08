using System.Threading.Tasks;
using Application.CQRS.Ocelot.GlobalConfigurations.Commands.CreateGlobalConfiguration;
using Application.CQRS.Ocelot.GlobalConfigurations.Commands.DeleteGlobalConfiguration;
using Application.CQRS.Ocelot.GlobalConfigurations.Commands.UpdateGlobalConfiguration;
using Application.CQRS.Ocelot.GlobalConfigurations.Queries.GetGlobalConfiguration;
using Application.CQRS.Ocelot.GlobalConfigurations.Queries.GetGlobalConfigurationsList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers.Ocelot
{
    public class GlobalConfigurationsController : BaseController
    {
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateGlobalConfigurationCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteGlobalConfigurationCommand() {Id = id});

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateGlobalConfigurationCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GlobalConfigurationDetailViewModel>> Get(int id)
        {
            return await Mediator.Send(new GetGlobalConfigurationDetailQuery() {Id = id});
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<GlobalConfigurationsListViewModel>> GetAll()
        {
            return await Mediator.Send(new GetGlobalConfigurationsListQuery());
        }
    }
}