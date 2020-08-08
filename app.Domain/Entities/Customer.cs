using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Customer : Base
    {
        [Required]
        [StringLength(100)]
        public string Name { get; private set; }

        private Customer() { }

        public Customer(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Nome deve ser informado");
        }
    }
}