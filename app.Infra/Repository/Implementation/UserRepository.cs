﻿using Domain.Entities;
using Infra.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Infra.Repository.Implementation
{
    public class UserRepository: IUserRepository
    {
        private DatabaseContext _context;

        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        public User Get(int Id)
        {
            return _context.User.Where(
                     p => p.Id == Id).FirstOrDefault();
        }
        public User Get(string Email, string Password)
        {
            return _context.User.Where(
                     p => p.Email == Email && p.Password == Password).FirstOrDefault();
        }

        public IEnumerable<User> List()
        {
            return _context.User
                .OrderBy(p => p.Id).ToList();
        }

        public bool Incluir(User user)
        {
            try
            {
                _context.User.Add(user);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

        public bool Update(User user)
        {
            try
            {
                User selectedUser = _context.User.Where(
                      p => p.Id == user.Id).FirstOrDefault();

                selectedUser.Name = user.Name;
                selectedUser.Identity = user.Identity;
                selectedUser.Telephone = user.Telephone;              
                selectedUser.BirthDate = user.BirthDate;
                _context.SaveChanges();

            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }

        public bool Excluir(int Id)
        {
            try
            {
                User produto = Get(Id);

                _context.User.Remove(produto);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }

            return true;
        }
    }
}
