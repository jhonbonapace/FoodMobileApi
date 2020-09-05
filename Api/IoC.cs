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

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            #region Automapper
            var _automapper = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Application.DTO.CustomerDto, Domain.Entities.Customer>();
                cfg.CreateMap<Application.DTO.UserDTO, Domain.Entities.User>();
                cfg.CreateMap<Application.DTO.UserFavoriteCustomerDTO, Domain.Entities.UserFavoriteCustomers>();           
            });
            IMapper mapper = _automapper.CreateMapper();

            services.AddSingleton(mapper);
            #endregion

            #region Fluent Validator
            services.AddMvc()
            .AddFluentValidation(fv =>
            fv.RegisterValidatorsFromAssemblyContaining<UserDTOValidator>()
            );
            #endregion

            return services;
        }
    }
}