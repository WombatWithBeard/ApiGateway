using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.CQRS.Ocelot.LoadBalancerOptions.Queries.GetLoadBalancerOptionsList
{
    public class GetLoadBalancerOptionsListQuery : IRequest<LoadBalancerOptionsListViewModel>
    {
        public class Handler : IRequestHandler<GetLoadBalancerOptionsListQuery, LoadBalancerOptionsListViewModel>
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

            public async Task<LoadBalancerOptionsListViewModel> Handle(GetLoadBalancerOptionsListQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var vm = new LoadBalancerOptionsListViewModel
                    {
                        ListDtos = await _context.LoadBalancerOptions.AsNoTracking()
                            .ProjectTo<LoadBalancerOptionsListDto>(_mapper.ConfigurationProvider)
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