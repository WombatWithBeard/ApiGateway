using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Ocelot.DownstreamHostAndPorts.Queries.GetDownstreamHostAndPortsList
{
    public class GetDownstreamHostAndPortsListQuery : IRequest<DownstreamHostAndPortsListViewModel>
    {
        public class Handler : IRequestHandler<GetDownstreamHostAndPortsListQuery, DownstreamHostAndPortsListViewModel>
        {
            private readonly IApiGatewayDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IApiGatewayDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<DownstreamHostAndPortsListViewModel> Handle(GetDownstreamHostAndPortsListQuery request,
                CancellationToken cancellationToken)
            {
                var vm = new DownstreamHostAndPortsListViewModel
                {
                    ListDtos = await _context.DownstreamHostAndPorts.AsNoTracking()
                        .ProjectTo<DownstreamHostAndPortsListDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken)
                };

                return vm;
            }
        }
    }
}