using ApplicationLayer.Interfaces.IAuthRepository;
using ApplicationLayer.Interfaces.IGenericIRepository;
using ApplicationLayer.Interfaces.ItemInterface;
using ApplicationLayer.Interfaces.Repositories;
using infrastructureLayer.Database;
using infrastructureLayer.Repositories;
using InfrastructureLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructureLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configration)
        {
            // Register all services, packages, dependence osv...
            // DB + repository
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configration.GetConnectionString("HananCleanArchitectureDbString"));

            });

            services.AddScoped<DbContext, AppDbContext>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IUserRepository, UserRepository>();




            services.AddScoped<AuthRepository>();


            return services;
        }
    }
}
