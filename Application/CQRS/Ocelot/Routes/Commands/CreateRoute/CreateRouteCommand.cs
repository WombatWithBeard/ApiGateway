using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Routes;
using MediatR;

namespace Application.CQRS.Ocelot.Routes.Commands.CreateRoute
{
    public class CreateRouteCommand : BaseRouteDto, IRequest, IMapFrom<CreateRouteCommand>
    {
        public class Handler : IRequestHandler<CreateRouteCommand>
        {
            private readonly IApiGatewayDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IApiGatewayDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(CreateRouteCommand request, CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<Route>(request);

                await _context.Routes.AddAsync(entity, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);
                
                return Unit.Value;
            }
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateRouteCommand, Route>()
                .ForMember(d => d.RouteId, opt => opt.MapFrom(e => e.RouteId));
        }
    }
}