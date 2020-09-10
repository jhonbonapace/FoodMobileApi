using Application.DTO;
using Application.Interface;
using AutoMapper;
using CrossCuting.Extensions;
using CrossCutting.Extensions;
using Domain.Entities;
using Domain.Helpers;
using Domain.Models;
using Infra.Repository;
using Infra.Repository.Implementation;
using Infra.Repository.Interface;
using System;

namespace Application.Services
{
    public class RecoveryService : IRecoveryService
    {
        IMapper _mapper;
        Serilog.Core.Logger _logger;
        private AppSettings _appSettings;
        private IUserRepository _userRepository;
        private IRecoveryRepository _repository;

        public RecoveryService(DatabaseContext context, IMapper mapper, AppSettings appSettings)
        {
            LoggerExtension logger = new LoggerExtension();
            _mapper = mapper;
            _logger = logger.CreateLogger();
            _repository = new RecoveryRepository(context);
            _userRepository = new UserRepository(context);
            _appSettings = appSettings;
        }

        public ResponseModel<PasswordRecoveryDTO> Get(int IdRecovery, string Hash, string Email)
        {
            ResponseModel<PasswordRecoveryDTO> model = new ResponseModel<PasswordRecoveryDTO>();

            try
            {
                PasswordRecovery item = _repository.Get(IdRecovery, Hash, Email);

                model.Data = _mapper.Map<PasswordRecoveryDTO>(item);

                if (model.Data != null)
                    model.Success = model.Data.ExpireDate > DateTime.Now ? true : false;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                model.Success = false;
            }

            return model;
        }

        public ResponseModel<bool> Add(string Email)
        {
            ResponseModel<bool> model = new ResponseModel<bool>();

            try
            {
                // Create new instance of  recovery object
                PasswordRecovery recovery;
                // Get user response
                User user = _userRepository.Get(Email);
                // Validate response
                if (user != null)
                {
                    //Create Hash string
                    string HashInput = string.Concat(user.Id, user.Email, DateTime.Now.ToString());

                    //new recovery object
                    recovery = new PasswordRecovery
                    {
                        HashKey = AuthExtensions.GenerateRecoveryHash(HashInput),
                        User = _mapper.Map<User>(user),
                        UserId = user.Id,
                        ExpireDate = DateTime.Now.AddDays(3),
                        SetOn = DateTime.Now
                    };

                    model.Data = _repository.Add(recovery);
                }

                model.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                model.Success = false;
            }

            return model;
        }

        public ResponseModel<bool> ChangePassword(PasswordRecoveryDTO recovery)
        {
            ResponseModel<bool> model = new ResponseModel<bool>();

            try
            {
                User user = _userRepository.Get(recovery.User.Email);

                if (user != null)
                {
                    AuthExtensions authExtensions = new AuthExtensions(_appSettings);

                    authExtensions.GeneratePassword(recovery.Password, out string PasswordSalt, out string PasswordHash);

                    user.PasswordHash = PasswordHash;
                    user.PasswordSalt = PasswordSalt;

                    var response = _userRepository.Update(user);

                    PasswordRecovery item = _mapper.Map<PasswordRecovery>(recovery);

                    item.Recovered = true;
                    item.ModifiedOn = DateTime.Now;

                    model.Data = _repository.Update(item);

                    model.Success = true;
                }
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
