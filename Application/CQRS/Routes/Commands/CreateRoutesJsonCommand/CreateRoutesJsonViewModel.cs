using System.Collections.Generic;
using Domain.Entities.Routes;

namespace Application.CQRS.Routes.Commands.CreateRoutesJsonCommand
{
    public class CreateRoutesJsonViewModel
    {
        public List<CreateRoutesJsonDto> ReRoutes { get; set; }
        public GlobalConfiguration GlobalConfiguration { get; set; }
    }
}