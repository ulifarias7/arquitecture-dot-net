using Application.Ports.Primary;
using Application.Ports.Secondary;
using Infrastructure.Adapters.Primary;
using Infrastructure.Adapters.Secondary;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        IConfiguration configuration)
        {
            // Database Context
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            //Repositories (Secondary Adapters)
            services.AddScoped<IUserRepository, UserRepository>();

            //Services (Primary Adapters)
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
