using Application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface IUserService
    {
        ResponseModel<User> Get(int Id);
        ResponseModel<User> Get(string Email);
        ResponseModel<User> Get(string Username, string Password);
        ResponseModel<IEnumerable<User>> List();
        ResponseModel Add(User user);
        ResponseModel Update(User user);
        ResponseModel Delete(int Id);
    }
}
