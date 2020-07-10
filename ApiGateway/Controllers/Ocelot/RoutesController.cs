using System.Threading.Tasks;
using Application.CQRS.Ocelot.Routes.Commands.CreateRoute;
using Application.CQRS.Ocelot.Routes.Commands.DeleteRoute;
using Application.CQRS.Ocelot.Routes.Commands.SaveRoutesJson;
using Application.CQRS.Ocelot.Routes.Commands.UpdateRoute;
using Application.CQRS.Ocelot.Routes.Queries.GetRoute;
using Application.CQRS.Ocelot.Routes.Queries.GetRoutesList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiGateway.Controllers.Ocelot
{
    public class RoutesController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> SaveRoutes()
        {
            await Mediator.Send(new SaveRoutesJsonCommand());

            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateRouteCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteRouteCommand {Id = id});

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateRouteCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RouteDetailViewModel>> Get(int id)
        {
            return await Mediator.Send(new GetRouteDetailQuery {Id = id});
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<RoutesListViewModel>> GetAll()
        {
            return await Mediator.Send(new GetRoutesListQuery());
        }
    }
}