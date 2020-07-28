using Application.DTO;
using Application.Interface;
using CrossCuting.Extensions;
using Domain.Entities;
using Domain.Helpers;
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

        public ResponseModel<User> Get(int Id)
        {
            ResponseModel<User> model = new ResponseModel<User>();

            try
            {

                User user = _userRepository.Get(Id);

                model.Response.Data = user;

                model.Response.Success = true;

            }
            catch (Exception)
            {

                model.Response.Success = false;
            }

            return model;
        }

        public ResponseModel<User> Get(string Email)
        {
            ResponseModel<User> model = new ResponseModel<User>();

            try
            {
                User user = _userRepository.Get(Email);

                model.Response.Data = user;

                model.Response.Success = true;

            }
            catch (Exception)
            {

                model.Response.Success = false;
            }

            return model;
        }

        public ResponseModel<User> Get(string Email, string Password)
        {
            ResponseModel<User> model = new ResponseModel<User>();

            try
            {
                User user = _userRepository.Get(Email);

                if (user != null)
                {
                    AuthExtensions authExtensions = new AuthExtensions(_appSettings);

                    user.Password = Password;

                    model.Response.Success = authExtensions.ValidatePassword(user);

                    model.Response.Data = model.Response.Success ? user : null;
                }
                else
                    model.Response.Success = false;

            }
            catch (Exception)
            {

                model.Response.Success = false;
            }

            return model;
        }

        public ResponseModel<IEnumerable<User>> List()
        {
            ResponseModel<IEnumerable<User>> model = new ResponseModel<IEnumerable<User>>();

            try
            {
                model.Response.Data = _userRepository.List();

                model.Response.Success = true;

            }
            catch (Exception)
            {
                model.Response.Success = false;
            }

            return model;
        }

        public ResponseModel Add(User user)
        {

            ResponseModel model = new ResponseModel();

            try
            {
                User HasUser = _userRepository.Get(user.Email);

                if (HasUser is null)
                {
                    AuthExtensions authExtensions = new AuthExtensions(_appSettings);

                    authExtensions.GeneratePassword(ref user);

                    _userRepository.Add(user);

                    model.Success = true;
                }
                else
                {
                    model.Message = "The email already exists.";
                    model.Success = false;
                }
            }
            catch (Exception)
            {

                model.Success = false;
            }

            return model;
        }

        public ResponseModel Update(User user)
        {

            ResponseModel model = new ResponseModel();

            try
            {
                _userRepository.Update(user);

                model.Success = true;
            }
            catch (Exception)
            {

                model.Success = false;
            }

            return model;
        }

        public ResponseModel Delete(int Id)
        {

            ResponseModel model = new ResponseModel();

            try
            {
                _userRepository.Delete(Id);

                model.Success = true;
            }
            catch (Exception)
            {

                model.Success = false;
            }

            return model;
        }
    }
}
