using System.Collections.Generic;
using Application.Common.Responses;

namespace Application.CQRS.Ocelot.AuthenticationOptions.Queries.GetAuthenticationOptionsList
{
    public class AuthenticationOptionsListViewModel : BaseResponse
    {
        public List<AuthenticationOptionsListDto> ListDtos { get; set; }
    }
}