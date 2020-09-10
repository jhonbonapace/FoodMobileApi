using Application.DTO;
using Application.Interface;
using AutoMapper;
using CrossCutting.Extensions;
using Domain.Entities;
using Infra.Repository;
using Infra.Repository.Implementation;
using Infra.Repository.Interface;
using System;
using System.Collections.Generic;

namespace Application.Services
{
    public class FavoriteService : IFavoriteService
    {
        IMapper _mapper;
        Serilog.Core.Logger _logger;
        private IFavoriteRepository _repository;

        public FavoriteService(DatabaseContext context, IMapper mapper)
        {
            _mapper = mapper;
            LoggerExtension logger = new LoggerExtension();
            _logger = logger.CreateLogger();
            _repository = new FavoriteRepository(context);
        }

        public ResponseModel<List<UserFavoriteCustomerDTO>> List(int IdUser)
        {
            ResponseModel<List<UserFavoriteCustomerDTO>> model = new ResponseModel<List<UserFavoriteCustomerDTO>>();

            try
            {
                List<UserFavoriteCustomer> itens = _repository.List(IdUser);

                model.Data = _mapper.Map<List<UserFavoriteCustomerDTO>>(itens);

                model.Success = true;

            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                model.Success = false;
            }

            return model;
        }

        public ResponseModel<bool> Add(UserFavoriteCustomerDTO favoriteItem)
        {
            ResponseModel<bool> model = new ResponseModel<bool>();

            try
            {
                var item = _mapper.Map<UserFavoriteCustomer>(favoriteItem);

                model.Data = _repository.Add(item);

                model.Success = true;

            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                model.Success = false;
            }

            return model;
        }
        public ResponseModel<bool> Delete(int Id)
        {
            ResponseModel<bool> model = new ResponseModel<bool>();

            try
            {
                model.Data = _repository.Delete(Id);

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
