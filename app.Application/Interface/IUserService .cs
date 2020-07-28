using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface IUserService
    {
        User Get(int Id);
        User Get(string Username, string Password);
        bool Add(User user);
    }
}
