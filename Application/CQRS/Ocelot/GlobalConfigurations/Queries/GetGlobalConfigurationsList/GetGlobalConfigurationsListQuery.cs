using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.CQRS.Ocelot.GlobalConfigurations.Queries.GetGlobalConfigurationsList
{
    public class GetGlobalConfigurationsListQuery : IRequest<GlobalConfigurationsListViewModel>
    {
        public class Handler : IRequestHandler<GetGlobalConfigurationsListQuery, GlobalConfigurationsListViewModel>
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

            public async Task<GlobalConfigurationsListViewModel> Handle(GetGlobalConfigurationsListQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var vm = new GlobalConfigurationsListViewModel
                    {
                        ListDtos = await _context.GlobalConfigurations.AsNoTracking()
                            .ProjectTo<GlobalConfigurationsListDto>(_mapper.ConfigurationProvider)
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