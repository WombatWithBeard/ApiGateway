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

namespace Application.CQRS.Ocelot.RouteClaimsRequirements.Queries.GetRouteClaimsRequirement
{
    public class GetRouteClaimsRequirementDetailQuery : IRequest<RouteClaimsRequirementDetailViewModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetRouteClaimsRequirementDetailQuery,
            RouteClaimsRequirementDetailViewModel>
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

            public async Task<RouteClaimsRequirementDetailViewModel> Handle(
                GetRouteClaimsRequirementDetailQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var vm = new RouteClaimsRequirementDetailViewModel
                    {
                        Dto = await _context.RouteClaimsRequirements.AsNoTracking()
                            .Where(d => d.RouteClaimsRequirementId == request.Id)
                            .ProjectTo<RouteClaimsRequirementDetailDto>(_mapper.ConfigurationProvider)
                            .SingleOrDefaultAsync(cancellationToken)
                    };

                    if (vm.Dto == null)
                        throw new NotFoundException(nameof(RouteClaimsRequirement), request.Id);

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