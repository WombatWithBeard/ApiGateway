using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Routes;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.CQRS.Ocelot.LoadBalancerOptions.Commands.CreateLoadBalancerOption
{
    public class CreateLoadBalancerOptionCommand : BaseLoadBalancerOptionDto, IRequest,
        IMapFrom<CreateLoadBalancerOptionCommand>
    {
        public class Handler : IRequestHandler<CreateLoadBalancerOptionCommand>
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

            public async Task<Unit> Handle(CreateLoadBalancerOptionCommand request, CancellationToken cancellationToken)
            {
                try
                {
                    var entity = _mapper.Map<LoadBalancerOption>(request);

                    await _context.LoadBalancerOptions.AddAsync(entity, cancellationToken);

                    await _context.SaveChangesAsync(cancellationToken);

                    return Unit.Value;
                }
                catch (Exception e)
                {
                    _logger.LogError(e.Message);
                    throw;
                }
            }
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateLoadBalancerOptionCommand, LoadBalancerOption>()
                .ForMember(d => d.LoadBalancerOptionId, opt => opt.MapFrom(e => e.LoadBalancerOptionId));
        }
    }
}