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

namespace Application.CQRS.Ocelot.DownstreamHostAndPorts.Queries.GetDownstreamHostAndPort
{
    public class GetDownstreamHostAndPortDetailQuery : IRequest<DownstreamHostAndPortDetailViewModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetDownstreamHostAndPortDetailQuery, DownstreamHostAndPortDetailViewModel
        >
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

            public async Task<DownstreamHostAndPortDetailViewModel> Handle(GetDownstreamHostAndPortDetailQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var vm = new DownstreamHostAndPortDetailViewModel
                    {
                        Dto = await _context.DownstreamHostAndPorts.AsNoTracking()
                            .Where(d => d.DownstreamHostAndPortId == request.Id)
                            .ProjectTo<DownstreamHostAndPortDetailDto>(_mapper.ConfigurationProvider)
                            .SingleOrDefaultAsync(cancellationToken)
                    };

                    if (vm.Dto == null)
                        throw new NotFoundException(nameof(DownstreamHostAndPort), request.Id);

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