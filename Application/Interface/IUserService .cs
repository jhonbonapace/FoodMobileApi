using Application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface IUserService
    {
        ResponseModel<UserDTO> Get(int Id);
        ResponseModel<UserDTO> Get(string Email);
        ResponseModel<UserDTO> Get(string Username, string Password);
        ResponseModel<List<UserDTO>> List();
        ResponseModel<UserDTO> Add(UserDTO user);
        ResponseModel Update(UserDTO user);
        ResponseModel Delete(int Id);
    }
}
