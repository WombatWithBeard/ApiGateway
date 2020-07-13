using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.CQRS.Ocelot.DownstreamHostAndPorts.Queries.GetDownstreamHostAndPortsList
{
    public class GetDownstreamHostAndPortsListQuery : IRequest<DownstreamHostAndPortsListViewModel>
    {
        public class Handler : IRequestHandler<GetDownstreamHostAndPortsListQuery, DownstreamHostAndPortsListViewModel>
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

            public async Task<DownstreamHostAndPortsListViewModel> Handle(GetDownstreamHostAndPortsListQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var vm = new DownstreamHostAndPortsListViewModel
                    {
                        ListDtos = await _context.DownstreamHostAndPorts.AsNoTracking()
                            .ProjectTo<DownstreamHostAndPortsListDto>(_mapper.ConfigurationProvider)
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