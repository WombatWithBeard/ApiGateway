using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Application.CQRS.Ocelot.Routes.Queries.GetRoute;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities.Routes;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.CQRS.Ocelot.AuthenticationOptions.Queries.GetAuthenticationOption
{
    public class GetAuthenticationOptionDetailQuery : IRequest<AuthenticationOptionDetailViewModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetAuthenticationOptionDetailQuery, AuthenticationOptionDetailViewModel>
        {
            private readonly IApiGatewayDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IApiGatewayDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AuthenticationOptionDetailViewModel> Handle(GetAuthenticationOptionDetailQuery request,
                CancellationToken cancellationToken)
            {
                var vm = new AuthenticationOptionDetailViewModel
                {
                    Dto = await _context.AuthenticationOptions.Where(d => d.AuthenticationOptionId == request.Id)
                        .ProjectTo<AuthenticationOptionDetailDto>(_mapper.ConfigurationProvider)
                        .SingleOrDefaultAsync(cancellationToken)
                };

                if (vm.Dto == null)
                    throw new NotFoundException(nameof(AuthenticationOption), request.Id);

                return vm;
            }
        }
    }
}