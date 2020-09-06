using Application.DTO;
using Application.Interface;
using Application.Services;
using AutoMapper;
using Domain.Entities;
using Domain.Models;
using FluentValidation.AspNetCore;
using Infra.Repository.Implementation;
using Infra.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    public static class IoC
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            services.AddTransient<CustomerService>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            #region Automapper
            var _automapper = new MapperConfiguration(cfg =>
            {
                #region User
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
                #endregion
                #region Customer
                cfg.CreateMap<Customer, CustomerDto>();
                cfg.CreateMap<CustomerDto,Customer>();
                #endregion
                #region UserFavortiteCustomer
                cfg.CreateMap<UserFavoriteCustomer, UserFavoriteCustomerDTO>();
                cfg.CreateMap<UserFavoriteCustomerDTO, UserFavoriteCustomer>();
                #endregion
                #region PasswordRecovery
                cfg.CreateMap<PasswordRecovery, PasswordRecoveryDTO>();
                cfg.CreateMap<PasswordRecoveryDTO, PasswordRecovery>();
                #endregion
            });
            IMapper mapper = _automapper.CreateMapper();

            services.AddSingleton(mapper);
            #endregion

            #region Fluent Validators
            services.AddMvc()
            .AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<UserDTOValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<UserFavoriteCustomerDTOValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<PasswordRecoveryDTOValidator>();
            }
            );
            #endregion

            return services;
        }
    }
}