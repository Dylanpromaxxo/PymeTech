using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PymeTech.Application.Common.Interfaces;
using PymeTech.Infrastructure.Persistence;
using PymeTech.Infrastructure.Persistence.Repositories;
using PymeTech.Infrastructure.Persistence.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PymeTech.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // Repositorios
            services.AddScoped<ITenantRepository, TenantRepository>();
            services.AddScoped<IPermisosRepository, PermisosRepository>();
            services.AddScoped<IRolesRepository, RolesRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            // Servicios
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            //services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddHttpContextAccessor();

            return services;
        }
    }
}
