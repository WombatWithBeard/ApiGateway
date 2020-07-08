using System.Threading.Tasks;
using Application.CQRS.Ocelot.DownstreamHostAndPorts.Commands.CreateDownstreamHostAndPort;
using Application.CQRS.Ocelot.DownstreamHostAndPorts.Commands.DeleteDownstreamHostAndPort;
using Application.CQRS.Ocelot.DownstreamHostAndPorts.Commands.UpdateDownstreamHostAndPort;
using Application.CQRS.Ocelot.DownstreamHostAndPorts.Queries.GetDownstreamHostAndPort;
using Application.CQRS.Ocelot.DownstreamHostAndPorts.Queries.GetDownstreamHostAndPortsList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers.Ocelot
{
    public class DownstreamHostAndPortsController : BaseController
    {
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateDownstreamHostAndPortCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteDownstreamHostAndPortCommand() {Id = id});

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateDownstreamHostAndPortCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DownstreamHostAndPortDetailViewModel>> Get(int id)
        {
            return await Mediator.Send(new GetDownstreamHostAndPortDetailQuery {Id = id});
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<DownstreamHostAndPortsListViewModel>> GetAll()
        {
            return await Mediator.Send(new GetDownstreamHostAndPortsListQuery());
        }
    }
}