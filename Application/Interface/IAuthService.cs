using Application.DTO.Auth;

namespace Application.Interface
{
    public interface IAuthService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
    }
}
