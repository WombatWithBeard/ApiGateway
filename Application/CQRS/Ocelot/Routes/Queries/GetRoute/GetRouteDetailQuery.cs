using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Routes;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.CQRS.Ocelot.Routes.Queries.GetRoute
{
    public class GetRouteDetailQuery : IRequest<RouteDetailViewModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetRouteDetailQuery, RouteDetailViewModel>
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

            public async Task<RouteDetailViewModel> Handle(GetRouteDetailQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var vm = new RouteDetailViewModel
                    {
                        Dto = await _context.Routes.AsNoTracking()
                            .Where(d => d.RouteId == request.Id)
                            .Include(p => p.LoadBalancerOptions)
                            .Include(p => p.DownstreamHostAndPorts)
                            .Include(p => p.UpstreamHttpMethod)
                            .Include(p => p.AuthenticationOptions)
                            .ThenInclude(option => option.AllowedScopes)
                            .ProjectTo<RouteDetailDto>(_mapper.ConfigurationProvider)
                            .SingleOrDefaultAsync(cancellationToken)
                    };

                    if (vm.Dto == null)
                        throw new NotFoundException(nameof(Route), request.Id);

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