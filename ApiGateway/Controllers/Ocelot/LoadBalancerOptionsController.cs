using System.Threading.Tasks;
using Application.CQRS.Ocelot.LoadBalancerOptions.Commands.CreateLoadBalancerOption;
using Application.CQRS.Ocelot.LoadBalancerOptions.Commands.DeleteLoadBalancerOption;
using Application.CQRS.Ocelot.LoadBalancerOptions.Commands.UpdateLoadBalancerOption;
using Application.CQRS.Ocelot.LoadBalancerOptions.Queries.GetLoadBalancerOption;
using Application.CQRS.Ocelot.LoadBalancerOptions.Queries.GetLoadBalancerOptionsList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers.Ocelot
{
    public class LoadBalancerOptionsController : BaseController
    {
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateLoadBalancerOptionCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteLoadBalancerOptionCommand() {Id = id});

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateLoadBalancerOptionCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<LoadBalancerOptionDetailViewModel>> Get(int id)
        {
            return await Mediator.Send(new GetLoadBalancerOptionDetailQuery {Id = id});
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<LoadBalancerOptionsListViewModel>> GetAll()
        {
            return await Mediator.Send(new GetLoadBalancerOptionsListQuery());
        }
    }
}