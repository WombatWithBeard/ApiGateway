using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.CQRS.Ocelot.Routes.Queries.GetRoutesList
{
    public class GetRoutesListQuery : IRequest<RoutesListViewModel>
    {
        public class Handler : IRequestHandler<GetRoutesListQuery, RoutesListViewModel>
        {
            private readonly IApiGatewayDbContext _context;
            private readonly IMapper _mapper;
            private readonly ILogger<Handler> _logger;

            public Handler(IApiGatewayDbContext context, IMapper mapper, ILogger<Handler> logger)
            {
                _context = context;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<RoutesListViewModel> Handle(GetRoutesListQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var vm = new RoutesListViewModel
                    {
                        ListDtos = await _context.Routes.AsNoTracking()
                            .Include(p => p.LoadBalancerOptions)
                            .Include(p => p.DownstreamHostAndPorts)
                            .Include(p => p.UpstreamHttpMethod)
                            .Include(p => p.AuthenticationOptions)
                            .ThenInclude(option => option.AllowedScopes)
                            .ProjectTo<RouteListDto>(_mapper.ConfigurationProvider)
                            .ToListAsync(cancellationToken)
                    };

                    return vm;
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    throw;
                }
            }
        }
    }
}