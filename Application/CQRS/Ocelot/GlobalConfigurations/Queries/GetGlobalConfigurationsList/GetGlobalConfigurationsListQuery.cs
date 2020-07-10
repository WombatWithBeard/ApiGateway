using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Ocelot.GlobalConfigurations.Queries.GetGlobalConfigurationsList
{
    public class GetGlobalConfigurationsListQuery : IRequest<GlobalConfigurationsListViewModel>
    {
        public class Handler : IRequestHandler<GetGlobalConfigurationsListQuery, GlobalConfigurationsListViewModel>
        {
            private readonly IApiGatewayDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IApiGatewayDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GlobalConfigurationsListViewModel> Handle(GetGlobalConfigurationsListQuery request,
                CancellationToken cancellationToken)
            {
                var vm = new GlobalConfigurationsListViewModel
                {
                    ListDtos = await _context.GlobalConfigurations.AsNoTracking()
                        .ProjectTo<GlobalConfigurationsListDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken)
                };

                return vm;
            }
        }
    }
}