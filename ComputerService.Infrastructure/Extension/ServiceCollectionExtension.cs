using ComputerService.Domain.Interfaces;
using ComputerService.Infrastructure.Persistence;
using ComputerService.Infrastructure.Repositories;
using ComputerService.Infrastructure.Seeders;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerService.Infrastructure.Extension
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ComputerServiceDbContext>(options => options.UseSqlServer(
                configuration.GetConnectionString("ComputerService")));
            services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ComputerServiceDbContext>();

            services.AddScoped<ComputerServiceSeeder>();
            services.AddScoped<IComputerServiceRepository, ComputerServiceRepository>();
        }
    }
}
