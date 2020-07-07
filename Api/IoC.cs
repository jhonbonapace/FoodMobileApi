using Application.Services;
using Infra.Repository.Implementation;
using Infra.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace Api
{
    public static class IoC
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            services.AddTransient<RestaurantService>();

            services.AddScoped<IRestaurantRepository, RestaurantRepository>();

            return services;
        }
    }
}