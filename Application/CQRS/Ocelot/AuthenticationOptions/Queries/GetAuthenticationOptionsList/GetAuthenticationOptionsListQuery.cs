using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.CQRS.Ocelot.AuthenticationOptions.Queries.GetAuthenticationOptionsList
{
    public class GetAuthenticationOptionsListQuery : IRequest<AuthenticationOptionsListViewModel>
    {
        public class Handler : IRequestHandler<GetAuthenticationOptionsListQuery, AuthenticationOptionsListViewModel>
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

            public async Task<AuthenticationOptionsListViewModel> Handle(GetAuthenticationOptionsListQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var vm = new AuthenticationOptionsListViewModel
                    {
                        ListDtos = await _context.AuthenticationOptions.AsNoTracking()
                            .ProjectTo<AuthenticationOptionsListDto>(_mapper.ConfigurationProvider)
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