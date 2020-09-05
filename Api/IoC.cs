using Application.DTO;
using Application.Interface;
using Application.Services;
using AutoMapper;
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
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEmailService, EmailService>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            #region Automapper
            var _automapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CustomerDto, Domain.Entities.Customer>();
                cfg.CreateMap<UserDTO, Domain.Entities.User>();
                cfg.CreateMap<UserFavoriteCustomerDTO, Domain.Entities.UserFavoriteCustomer>();
            });
            IMapper mapper = _automapper.CreateMapper();

            services.AddSingleton(mapper);
            #endregion

            #region Fluent Validator
            services.AddMvc()
            .AddFluentValidation(fv =>
            {
                fv.RegisterValidatorsFromAssemblyContaining<UserDTOValidator>();
                fv.RegisterValidatorsFromAssemblyContaining<UserFavoriteCustomerDTOValidator>();
            }
            );
            #endregion

            return services;
        }
    }
}