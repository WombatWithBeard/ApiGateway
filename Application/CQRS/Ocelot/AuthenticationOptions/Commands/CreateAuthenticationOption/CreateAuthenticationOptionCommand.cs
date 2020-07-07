using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using Application.Common.Mapping;
using AutoMapper;
using Domain.Entities.Routes;
using MediatR;

namespace Application.CQRS.Ocelot.AuthenticationOptions.Commands.CreateAuthenticationOption
{
    public class CreateAuthenticationOptionCommand : BaseAuthenticationOptionsDto, IRequest,
        IMapFrom<CreateAuthenticationOptionCommand>
    {
        public class Handler : IRequestHandler<CreateAuthenticationOptionCommand>
        {
            private readonly IApiGatewayDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IApiGatewayDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(CreateAuthenticationOptionCommand request,
                CancellationToken cancellationToken)
            {
                var entity = _mapper.Map<AuthenticationOption>(request);

                await _context.AuthenticationOptions.AddAsync(entity, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateAuthenticationOptionCommand, AuthenticationOption>()
                .ForMember(d => d.AuthenticationOptionId, opt => opt.MapFrom(e => e.AuthenticationOptionId));
        }
    }
}