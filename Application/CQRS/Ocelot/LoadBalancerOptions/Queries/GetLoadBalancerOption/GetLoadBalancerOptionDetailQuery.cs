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

namespace Application.CQRS.Ocelot.LoadBalancerOptions.Queries.GetLoadBalancerOption
{
    public class GetLoadBalancerOptionDetailQuery : IRequest<LoadBalancerOptionDetailViewModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetLoadBalancerOptionDetailQuery, LoadBalancerOptionDetailViewModel>
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

            public async Task<LoadBalancerOptionDetailViewModel> Handle(GetLoadBalancerOptionDetailQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var vm = new LoadBalancerOptionDetailViewModel
                    {
                        Dto = await _context.LoadBalancerOptions.AsNoTracking()
                            .Where(d => d.LoadBalancerOptionId == request.Id)
                            .ProjectTo<LoadBalancerOptionDetailDto>(_mapper.ConfigurationProvider)
                            .SingleOrDefaultAsync(cancellationToken)
                    };

                    if (vm.Dto == null)
                        throw new NotFoundException(nameof(LoadBalancerOption), request.Id);

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