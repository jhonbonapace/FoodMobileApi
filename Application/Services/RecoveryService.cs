using Application.DTO;
using Application.Interface;
using AutoMapper;
using CrossCuting.Extensions;
using CrossCutting.Extensions;
using Domain.Entities;
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
        private IUserService _userService;
        private IRecoveryRepository _repository;

        public RecoveryService(DatabaseContext context, IMapper mapper)
        {
            LoggerExtension logger = new LoggerExtension();
            _mapper = mapper;
            _logger = logger.CreateLogger();
            _repository = new RecoveryRepository(context);
            _userService = new UserService(context, _mapper);
        }

        public ResponseModel<PasswordRecoveryDTO> Get(int IdRecovery, string Hash, string Email)
        {
            ResponseModel<PasswordRecoveryDTO> model = new ResponseModel<PasswordRecoveryDTO>();

            try
            {
                PasswordRecovery item = _repository.Get(IdRecovery,Hash, Email);

                model.Response.Data = _mapper.Map<PasswordRecoveryDTO>(item);

                if (model.Response.Data != null)
                    model.Response.Success = model.Response.Data.ExpireDate > DateTime.Now ? true : false;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                model.Response.Success = false;
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
                ResponseModel<UserDTO> userResponse = _userService.Get(Email);
                // Validate response
                if (userResponse.Response.Data != null && userResponse.Response.Success)
                {
                    //Map response
                    User user = _mapper.Map<User>(userResponse.Response.Data);

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

                    model.Response.Data = _repository.Add(recovery);
                }

                model.Response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                model.Response.Success = false;
            }

            return model;
        }
    }
}
