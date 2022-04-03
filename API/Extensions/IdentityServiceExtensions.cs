using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence;

namespace API.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentityCore<User>(opt =>
                {
                })
                .AddEntityFrameworkStores<DataContext>()
                .AddSignInManager<SignInManager<User>>();

            services.AddAuthentication();

            return services;
        }
    }
}