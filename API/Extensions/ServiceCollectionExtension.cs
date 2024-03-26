using API.Data;
using API.Interfaces;
using API.Middlewares;
using API.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<ITokenService, TokenService>();

            return services;
        }
    }
}
