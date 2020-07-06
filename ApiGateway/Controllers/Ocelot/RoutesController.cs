using System;
using System.Threading.Tasks;
using Application.CQRS.Routes.Queries.GetRoute;
using Application.CQRS.Routes.Queries.GetRoutesList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Controllers.Ocelot
{
    public class RoutesController : BaseController
    {
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RouteDetailViewModel>> Get(int id)
        {
            try
            {
                return await Mediator.Send(new GetRouteDetailQuery() {Id = id});
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new RouteDetailViewModel
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<RoutesListViewModel>> GetAll()
        {
            try
            {
                return await Mediator.Send(new GetRoutesListQuery());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new RoutesListViewModel
                {
                    Success = false,
                    Message = e.Message
                };
            }
        }

        [HttpGet]
        public async Task<IActionResult> Seed()
        {
            try
            {
                

                return Ok("Data seeded");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return Ok(e.Message);
            }
        }
    }
}