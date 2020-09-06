using Application.DTO;

namespace Application.Interface
{
    public interface IRecoveryService
    {
        ResponseModel<PasswordRecoveryDTO> Get(int IdRecovery, string Hash, string Email);
        ResponseModel<bool> Add(string Email);
    }
}
