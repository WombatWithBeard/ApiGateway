using System.Threading.Tasks;
using Application.CQRS.Ocelot.AuthenticationOptions.Commands.CreateAuthenticationOption;
using Application.CQRS.Ocelot.AuthenticationOptions.Commands.DeleteAuthenticationOption;
using Application.CQRS.Ocelot.AuthenticationOptions.Commands.UpdateAuthenticationOption;
using Application.CQRS.Ocelot.AuthenticationOptions.Queries.GetAuthenticationOption;
using Application.CQRS.Ocelot.AuthenticationOptions.Queries.GetAuthenticationOptionsList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers.Ocelot
{
    public class AuthenticationOptionsController : BaseController
    {
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody] UpdateAuthenticationOptionCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteAuthenticationOptionCommand() {Id = id});

            return NoContent();
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> Create([FromBody] CreateAuthenticationOptionCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<AuthenticationOptionDetailViewModel>> Get(int id)
        {
            return await Mediator.Send(new GetAuthenticationOptionDetailQuery() {Id = id});
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AuthenticationOptionsListViewModel>> GetAll()
        {
            return await Mediator.Send(new GetAuthenticationOptionsListQuery());
        }
    }
}