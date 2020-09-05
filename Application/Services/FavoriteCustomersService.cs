using Application.DTO;
using Application.Interface;
using AutoMapper;
using CrossCutting.Extensions;
using Domain.Entities;
using Domain.Helpers;
using Infra.Repository;
using Infra.Repository.Implementation;
using Infra.Repository.Interface;
using System;
using System.Collections.Generic;

namespace Application.Services
{
    public class FavoriteCustomersService : IFavoriteCustomersService
    {
        IMapper _mapper;
        Serilog.Core.Logger _logger;
        private IFavoriteCustomersRepository _repository;

        public FavoriteCustomersService(DatabaseContext context, IMapper mapper)
        {
            _mapper = mapper;
            LoggerExtension logger = new LoggerExtension();
            _logger = logger.CreateLogger();
            _repository = new FavoriteCustomersRepository(context);
        }

        public ResponseModel<IEnumerable<UserFavoriteCustomerDTO>> List(int IdUser)
        {
            ResponseModel<IEnumerable<UserFavoriteCustomerDTO>> model = new ResponseModel<IEnumerable<UserFavoriteCustomerDTO>>();

            try
            {
                IEnumerable<UserFavoriteCustomers> itens = _repository.List(IdUser);

                model.Response.Data = _mapper.Map<IEnumerable<UserFavoriteCustomerDTO>>(itens);

                model.Response.Success = true;

            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                model.Response.Success = false;
            }

            return model;
        }

        public ResponseModel<bool> Add(UserFavoriteCustomerDTO favoriteItem)
        {
            ResponseModel<bool> model = new ResponseModel<bool>();

            try
            {
                var item = _mapper.Map<UserFavoriteCustomers>(favoriteItem);

                model.Response.Data = _repository.Add(item);

                model.Response.Success = true;

            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                model.Response.Success = false;
            }

            return model;
        }
        public ResponseModel<bool> Delete(int Id)
        {
            ResponseModel<bool> model = new ResponseModel<bool>();

            try
            {
                model.Response.Data = _repository.Delete(Id);

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
