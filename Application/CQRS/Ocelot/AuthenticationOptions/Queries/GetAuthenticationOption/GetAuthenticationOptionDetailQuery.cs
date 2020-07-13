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

namespace Application.CQRS.Ocelot.AuthenticationOptions.Queries.GetAuthenticationOption
{
    public class GetAuthenticationOptionDetailQuery : IRequest<AuthenticationOptionDetailViewModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetAuthenticationOptionDetailQuery, AuthenticationOptionDetailViewModel>
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

            public async Task<AuthenticationOptionDetailViewModel> Handle(GetAuthenticationOptionDetailQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var vm = new AuthenticationOptionDetailViewModel
                    {
                        Dto = await _context.AuthenticationOptions.AsNoTracking()
                            .Where(d => d.AuthenticationOptionId == request.Id)
                            .ProjectTo<AuthenticationOptionDetailDto>(_mapper.ConfigurationProvider)
                            .SingleOrDefaultAsync(cancellationToken)
                    };

                    if (vm.Dto == null)
                        throw new NotFoundException(nameof(AuthenticationOption), request.Id);

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