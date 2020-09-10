using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infra.Repository.Interface
{
    public interface IUserRepository
    {
        User Get(int Id);
        User Get(string Email);
        List<User> List();
        bool Add(User user);
        bool Update(User user);
        bool Delete(int Id);
    }
}
