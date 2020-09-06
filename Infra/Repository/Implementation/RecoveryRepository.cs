using Domain.Models;
using Infra.Repository.Interface;
using System;
using System.Linq;

namespace Infra.Repository.Implementation
{
    public class RecoveryRepository : IRecoveryRepository
    {
        private DatabaseContext _context;

        public RecoveryRepository(DatabaseContext context)
        {
            _context = context;
        }

        public PasswordRecovery Get(int Id, string Email, string Hash)
        {
            return _context.PasswordRecovery.Where(
                     p => p.Id == Id && p.HashKey == Hash && p.User.Email == Email).LastOrDefault();
        }

        public bool Add(PasswordRecovery recovery)
        {
            try
            {
                _context.PasswordRecovery.Add(recovery);
                _context.SaveChanges();

                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
