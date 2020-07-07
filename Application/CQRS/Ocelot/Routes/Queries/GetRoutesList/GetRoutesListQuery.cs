using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Ocelot.Routes.Queries.GetRoutesList
{
    public class GetRoutesListQuery : IRequest<RoutesListViewModel>
    {
        public class Handler : IRequestHandler<GetRoutesListQuery, RoutesListViewModel>
        {
            private readonly IApiGatewayDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IApiGatewayDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<RoutesListViewModel> Handle(GetRoutesListQuery request,
                CancellationToken cancellationToken)
            {
                var vm = new RoutesListViewModel
                {
                    ListDtos = await _context.Routes
                        .Include(p => p.AuthenticationOptions)
                        .Include(p => p.LoadBalancerOptions)
                        .Include(p => p.DownstreamHostAndPorts)
                        .ProjectTo<RouteListDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken)
                };
                
                return vm;
            }
        }
    }
}