﻿using System.ComponentModel.DataAnnotations;

namespace Application.DTO.Auth
{
    public class AuthenticateRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
