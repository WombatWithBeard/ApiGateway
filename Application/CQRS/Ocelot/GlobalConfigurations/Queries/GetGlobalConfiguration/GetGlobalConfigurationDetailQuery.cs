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

namespace Application.CQRS.Ocelot.GlobalConfigurations.Queries.GetGlobalConfiguration
{
    public class GetGlobalConfigurationDetailQuery : IRequest<GlobalConfigurationDetailViewModel>
    {
        public int Id { get; set; }

        public class Handler : IRequestHandler<GetGlobalConfigurationDetailQuery, GlobalConfigurationDetailViewModel>
        {
            private readonly IApiGatewayDbContext _context;
            private readonly IMapper _mapper;

            public Handler(IApiGatewayDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<GlobalConfigurationDetailViewModel> Handle(GetGlobalConfigurationDetailQuery request,
                CancellationToken cancellationToken)
            {
                var vm = new GlobalConfigurationDetailViewModel
                {
                    Dto = await _context.GlobalConfigurations.AsNoTracking()
                        .Where(d => d.GlobalConfigurationId == request.Id)
                        .ProjectTo<GlobalConfigurationDetailDto>(_mapper.ConfigurationProvider)
                        .SingleOrDefaultAsync(cancellationToken)
                };

                if (vm.Dto == null)
                    throw new NotFoundException(nameof(GlobalConfiguration), request.Id);

                return vm;
            }
        }
    }
}