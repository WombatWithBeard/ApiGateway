using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Ocelot.AuthenticationOptions.Queries.GetAuthenticationOptionsList
{
    public class GetAuthenticationOptionsListQuery : IRequest<AuthenticationOptionsListViewModel>
    {
        public class Handler : IRequestHandler<GetAuthenticationOptionsListQuery, AuthenticationOptionsListViewModel>
        {
            private readonly IApiGatewayDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IApiGatewayDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AuthenticationOptionsListViewModel> Handle(GetAuthenticationOptionsListQuery request,
                CancellationToken cancellationToken)
            {
                var vm = new AuthenticationOptionsListViewModel
                {
                    ListDtos = await _context.AuthenticationOptions.AsNoTracking()
                        .ProjectTo<AuthenticationOptionsListDto>(_mapper.ConfigurationProvider)
                        .ToListAsync(cancellationToken)
                };

                return vm;
            }
        }
    }
}