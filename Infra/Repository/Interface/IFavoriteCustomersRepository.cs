using Domain.Entities;
using System.Collections.Generic;

namespace Infra.Repository.Interface
{
    public interface IFavoriteCustomersRepository
    {
        IEnumerable<UserFavoriteCustomers> List(int IdUser);
        bool Add(UserFavoriteCustomers favoriteCustomers);
        bool Delete(int Id);
    }
}
