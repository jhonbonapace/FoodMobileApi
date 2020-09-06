using Domain.Models;

namespace Infra.Repository.Interface
{
    public interface IRecoveryRepository
    {
        PasswordRecovery Get(int IdRecovery, string Hash, string Email);
        bool Update(PasswordRecovery recovery);
        bool Add(PasswordRecovery recovery);
    }
}
