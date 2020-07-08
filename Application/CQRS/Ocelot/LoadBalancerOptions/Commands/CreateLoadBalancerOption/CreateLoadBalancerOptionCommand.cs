using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Routes;
using MediatR;

namespace Application.CQRS.Ocelot.LoadBalancerOptions.Commands.CreateLoadBalancerOption
{
    public class CreateLoadBalancerOptionCommand : BaseLoadBalancerOptionDto, IRequest,
        IMapFrom<CreateLoadBalancerOptionCommand>
    {
        public class Handler : IRequestHandler<CreateLoadBalancerOptionCommand>
        {
            private readonly IApiGatewayDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IApiGatewayDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(CreateLoadBalancerOptionCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<LoadBalancerOption>(request);

                await _context.LoadBalancerOptions.AddAsync(entity, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateLoadBalancerOptionCommand, LoadBalancerOption>()
                .ForMember(d => d.LoadBalancerOptionId, opt => opt.MapFrom(e => e.LoadBalancerOptionId));
        }
    }
}