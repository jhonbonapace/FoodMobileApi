using Domain.Models;

namespace Infra.Repository.Interface
{
    public interface IRecoveryRepository
    {
        PasswordRecovery Get(int IdRecovery, string Hash, string Email);
        bool Add(PasswordRecovery recovery);
    }
}
