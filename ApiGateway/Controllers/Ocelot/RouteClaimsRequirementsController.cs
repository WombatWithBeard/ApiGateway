using System.Threading.Tasks;
using Application.CQRS.Ocelot.RouteClaimsRequirements.Commands.CreateRouteClaimsRequirement;
using Application.CQRS.Ocelot.RouteClaimsRequirements.Commands.DeleteRouteClaimsRequirement;
using Application.CQRS.Ocelot.RouteClaimsRequirements.Commands.UpdateRouteClaimsRequirement;
using Application.CQRS.Ocelot.RouteClaimsRequirements.Queries.GetRouteClaimsRequirement;
using Application.CQRS.Ocelot.RouteClaimsRequirements.Queries.GetRouteClaimsRequirementsList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers.Ocelot
{
    public class RouteClaimsRequirementsController : BaseController
    {
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateRouteClaimsRequirementCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteRouteClaimsRequirementCommand() {Id = id});

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateRouteClaimsRequirementCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RouteClaimsRequirementDetailViewModel>> Get(int id)
        {
            return await Mediator.Send(new GetRouteClaimsRequirementDetailQuery {Id = id});
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<RouteClaimsRequirementsListViewModel>> GetAll()
        {
            return await Mediator.Send(new GetRouteClaimsRequirementsListQuery());
        }
    }
}