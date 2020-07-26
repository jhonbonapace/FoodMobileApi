using Application.Interface;
using Domain.Entities;
using Infra.Repository;
using Infra.Repository.Implementation;
using Infra.Repository.Interface;
using System;
using System.Collections.Generic;

namespace Application.Services
{

    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(DatabaseContext context)
        {
            _userRepository = new UserRepository(context);
        }

        public User Get(int Id)
        {
            try
            {
                return _userRepository.Get(Id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public User Get(string Email, string Password)
        {
            try
            {
                return _userRepository.Get(Email, Password);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<User> List()
        {
            try
            {
                return _userRepository.List();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool Incluir(User user)
        {
            try
            {
                return _userRepository.Incluir(user);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool Update(User user)
        {
            try
            {
                return _userRepository.Update(user);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public bool Excluir(int Id)
        {
            try
            {
                return _userRepository.Excluir(Id);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
