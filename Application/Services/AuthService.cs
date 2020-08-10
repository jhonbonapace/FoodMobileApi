using Application.DTO;
using Application.DTO.Auth;
using Application.Interface;
using CrossCutting.Extensions;
using Domain.Entities;
using Domain.Helpers;
using Infra.Repository;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class AuthService : IAuthService
    {
        Serilog.Core.Logger _logger;
        private readonly AppSettings _appSettings;
        private readonly DatabaseContext _context;

        public AuthService(IOptions<AppSettings> appSettings, DatabaseContext context)
        {
            LoggerExtension logger = new LoggerExtension();
            _logger = logger.CreateLogger();

            _appSettings = appSettings.Value;
            _context = context;
        }

        public ResponseModel<AuthenticateResponse> Authenticate(AuthenticateRequest auth, bool IsRegistration = false)
        {
            ResponseModel<AuthenticateResponse> model = new ResponseModel<AuthenticateResponse>();

            try
            {
                IUserService userService = new UserService(_context, _appSettings);

                ResponseModel<User> response;

                if (!IsRegistration)
                    response = userService.Get(auth.Email, auth.Password);
                else
                    response = userService.Get(auth.Email);


                if (response.Response.Success)
                {

                    var token = GenerateAuthToken(response.Response.Data);
                    model.Response.Data = new AuthenticateResponse(response.Response.Data, token);

                    model.Response.Success = true;
                }
                else
                {
                    model.Response.Message = "Username or password is incorrect.";
                    model.Response.Success = false;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, ex.Message);
                model.Response.Success = false;
            }

            return model;

        }

        private string GenerateAuthToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(_appSettings.DaysToExpire),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
