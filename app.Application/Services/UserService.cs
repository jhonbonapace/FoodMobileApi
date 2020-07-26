using Application.Interface;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{

    public class UserService : IUserService
    {
        private List<User> _users = new List<User>
        {
            new User { Id = 1, Name = "Test", Email = "luc-diogo@hotmail.com", Password = "123" }
        };

        public User Get(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public User Get(string Username, string Password)
        {
            return _users.FirstOrDefault(x => x.Email == Username && x.Password == Password);
        }
    }
}
