﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.CQRS.Ocelot.RouteClaimsRequirements.Queries.GetRouteClaimsRequirementsList
{
    public class GetRouteClaimsRequirementsListQuery : IRequest<RouteClaimsRequirementsListViewModel>
    {
        public class Handler : IRequestHandler<GetRouteClaimsRequirementsListQuery, RouteClaimsRequirementsListViewModel
        >
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

            public async Task<RouteClaimsRequirementsListViewModel> Handle(GetRouteClaimsRequirementsListQuery request,
                CancellationToken cancellationToken)
            {
                try
                {
                    var vm = new RouteClaimsRequirementsListViewModel
                    {
                        ListDtos = await _context.RouteClaimsRequirements.AsNoTracking()
                            .ProjectTo<RouteClaimsRequirementsListDto>(_mapper.ConfigurationProvider)
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