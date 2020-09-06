using Domain.Entities;
using System;

namespace Domain.Models
{
    public class PasswordRecovery: Base
    {

        public string HashKey { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime SetOn { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
