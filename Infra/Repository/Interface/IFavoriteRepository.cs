﻿using Domain.Entities;
using System.Collections.Generic;

namespace Infra.Repository.Interface
{
    public interface IFavoriteRepository
    {
        IEnumerable<UserFavoriteCustomer> List(int IdUser);
        bool Add(UserFavoriteCustomer item);
        bool Delete(int Id);
    }
}