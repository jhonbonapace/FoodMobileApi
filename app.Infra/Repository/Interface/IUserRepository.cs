using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repository.Interface
{
    public interface IUserRepository
    {
        User Get(int Id);
        User Get(string Email, string Password);
        IEnumerable<User> List();
        bool Incluir(User user);
        bool Update(User user);
        bool Excluir(int Id);
    }
}
