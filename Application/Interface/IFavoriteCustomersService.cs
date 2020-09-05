﻿using Application.DTO;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interface
{
    public interface IFavoriteCustomersService
    {
        ResponseModel<IEnumerable<UserFavoriteCustomerDTO>> List(int IdUser);
        ResponseModel<bool> Add(UserFavoriteCustomerDTO favoriteItem);
        public ResponseModel<bool> Delete(int Id);
    }
}