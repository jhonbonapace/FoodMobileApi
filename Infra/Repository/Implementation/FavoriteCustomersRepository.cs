﻿using Domain.Entities;
using Infra.Repository.Interface;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repository.Implementation
{
    public class FavoriteCustomersRepository : IFavoriteCustomersRepository
    {
        private DatabaseContext _context;

        public FavoriteCustomersRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<UserFavoriteCustomers> List(int IdUser)
        {
            return _context.UserFavoriteCustomers.Where(e => e.UserId == IdUser)
            .OrderBy(p => p.Id).ToList();
        }

        public bool Add(UserFavoriteCustomers favoriteCustomers)
        {
            try
            {
                _context.UserFavoriteCustomers.Add(favoriteCustomers);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int Id)
        {
            try
            {
                var item = _context.UserFavoriteCustomers.FirstOrDefault(e => e.Id == Id);

                _context.UserFavoriteCustomers.Remove(item);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
