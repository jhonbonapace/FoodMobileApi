using Application.DTO;
using Application.DTO.Auth;

namespace Application.Interface
{
    public interface IAuthService
    {
        ResponseModel<AuthenticateResponse> Authenticate(AuthenticateRequest auth, bool IsRegistration = false);
    }
}
