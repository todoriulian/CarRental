using CarRental.Application.Common.Interfaces;
using CarRental.Infrastructure.Persistence;
using CarRental.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CarRental.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //setup connection to dB
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                configuration["ConnectionStrings:DefaultConnection"],
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
            ));

            services.AddScoped<IRepository, Repository>();
            services.AddScoped<IClaimsTransformation, RoleClaimsTransformation>();

            return services;
        }
    }
}