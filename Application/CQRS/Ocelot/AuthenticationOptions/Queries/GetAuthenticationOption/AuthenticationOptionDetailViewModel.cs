using Application.Common.Responses;

namespace Application.CQRS.Ocelot.AuthenticationOptions.Queries.GetAuthenticationOption
{
    public class AuthenticationOptionDetailViewModel : BaseResponse
    {
        public AuthenticationOptionDetailDto Dto { get; set; }
    }
}