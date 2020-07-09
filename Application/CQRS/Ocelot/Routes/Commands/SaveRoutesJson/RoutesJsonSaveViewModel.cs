using System.Collections.Generic;
using Domain.Entities.Routes;

namespace Application.CQRS.Ocelot.Routes.Commands.SaveRoutesJson
{
    public class RoutesJsonSaveViewModel
    {
        public List<RoutesJsonSaveDto> Routes { get; set; }
        public GlobalConfiguration GlobalConfiguration { get; set; }
    }
}