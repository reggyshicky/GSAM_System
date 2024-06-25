using Application.Common;
using Application.Services;
using Application.UserManagement.Commands;
using Domain.IRepositories;
using Infrastructure.Repositories;
using LoginTestAPI.Services;


namespace LoginTestAPI
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });
            services.AddScoped<UserService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            return services;

        }
    }
}
