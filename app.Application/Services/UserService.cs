using Application.Interface;
using CrossCuting.Extensions;
using Domain.Entities;
using Domain.Helpers;
using Infra.Repository;
using Infra.Repository.Implementation;
using Infra.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services
{

    public class UserService : IUserService
    {
        private IUserRepository _userRepository;
        private AppSettings _appSettings;
        public UserService(DatabaseContext context, AppSettings appSettings)
        {
            _userRepository = new UserRepository(context);
            _appSettings = appSettings;
        }

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

                throw ex;
            }
        }

        public User Get(string Email, string Password)
        {
            try
            {
                User user = _userRepository.Get(Email);

                if (user != null)
                {
                    AuthExtensions authExtensions = new AuthExtensions(_appSettings);

                    user.Password = Password;
                    bool IsValid = authExtensions.ValidatePassword(user);

                    return IsValid ? user : null;
                }

                return null;
            }
            catch (Exception ex)
            {

                throw ex;
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

                throw ex;
            }
        }

        public bool Add(User user)
        {
            try
            {
                AuthExtensions authExtensions = new AuthExtensions(_appSettings);

                authExtensions.GeneratePassword(ref user);

                return _userRepository.Add(user);

            }
            catch (Exception ex)
            {

                throw ex;
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

        public bool Delete(int Id)
        {
            try
            {
                return _userRepository.Delete(Id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
