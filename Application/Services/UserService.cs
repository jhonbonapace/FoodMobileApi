using System;
using System.Collections.Generic;
using Application.DTO;
using Application.Interface;
using AutoMapper;
using CrossCuting.Extensions;
using CrossCutting.Extensions;
using Domain.Entities;
using Domain.Helpers;
using Infra.Repository;
using Infra.Repository.Implementation;
using Infra.Repository.Interface;

namespace Application.Services
{

    public class UserService : IUserService
    {
        Serilog.Core.Logger _logger;
        private IMapper _mapper;
        private AppSettings _appSettings;
        private IUserRepository _userRepository;
        public UserService(DatabaseContext context, IMapper mapper, AppSettings appSettings)
        {
            LoggerExtension logger = new LoggerExtension();
            _logger = logger.CreateLogger();
            _mapper = mapper;
            _userRepository = new UserRepository(context);
            _appSettings = appSettings;
        }

        public UserService(DatabaseContext context)
        {
            _userRepository = new UserRepository(context);
        }

        public ResponseModel<UserDTO> Get(int Id)
        {
            ResponseModel<UserDTO> model = new ResponseModel<UserDTO>();

            try
            {
                User user = _userRepository.Get(Id);

                model.Response.Data = _mapper.Map<UserDTO>(user);

                model.Response.Success = true;

            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                model.Response.Success = false;
            }

            return model;
        }

        public ResponseModel<UserDTO> Get(string Email)
        {
            ResponseModel<UserDTO> model = new ResponseModel<UserDTO>();

            try
            {
                User user = _userRepository.Get(Email);

                model.Response.Data = _mapper.Map<UserDTO>(user);

                model.Response.Success = true;

            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                model.Response.Success = false;
            }

            return model;
        }

        public ResponseModel<UserDTO> Get(string Email, string Password)
        {
            ResponseModel<UserDTO> model = new ResponseModel<UserDTO>();

            try
            {
                User user = _userRepository.Get(Email);

                if (user != null)
                {
                    AuthExtensions authExtensions = new AuthExtensions(_appSettings);

                    model.Response.Success = authExtensions.ValidatePassword(Password, user.PasswordHash, user.PasswordSalt);

                    model.Response.Data = model.Response.Success ? _mapper.Map<UserDTO>(user) : null;
                }
                else
                    model.Response.Success = false;

            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                model.Response.Success = false;
            }

            return model;
        }

        public ResponseModel<IEnumerable<UserDTO>> List()
        {
            ResponseModel<IEnumerable<UserDTO>> model = new ResponseModel<IEnumerable<UserDTO>>();

            try
            {
                IEnumerable<User> list = _userRepository.List();

                model.Response.Data = _mapper.Map<IEnumerable<UserDTO>>(list);

                model.Response.Success = true;

            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                model.Response.Success = false;
            }

            return model;
        }

        public ResponseModel<UserDTO> Add(UserDTO userDTO)
        {

            ResponseModel<UserDTO> model = new ResponseModel<UserDTO>();

            try
            {
                User HasUser = _userRepository.Get(userDTO.Email);

                if (HasUser is null)
                {
                    AuthExtensions authExtensions = new AuthExtensions(_appSettings);

                    User user = _mapper.Map<User>(userDTO);

                    authExtensions.GeneratePassword(userDTO.Password, out string PasswordHash,out string PasswordSalt);

                    user.PasswordHash = PasswordHash;
                    user.PasswordSalt = PasswordSalt;

                    var response = _userRepository.Add(user);

                    model.Response.Success = response;
                }
                else
                {
                    model.Response.Message = "O email informado já existe.";
                    model.Response.Success = false;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                model.Response.Success = false;
            }

            return model;
        }

        public ResponseModel Update(UserDTO UserDTO)
        {

            ResponseModel model = new ResponseModel();

            try
            {
                User user = _mapper.Map<User>(UserDTO);

                _userRepository.Update(user);

                model.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
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
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                model.Success = false;
            }

            return model;
        }
    }
}