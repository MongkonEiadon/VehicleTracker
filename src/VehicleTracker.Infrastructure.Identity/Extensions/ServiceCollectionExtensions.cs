using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using VehicleTracker.Infrastructure.Configurations;

namespace VehicleTracker.Infrastructure.Identity.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddVehicleAuthorizeService(this IServiceCollection services, EnvironmentConfiguration config) {


            services
                .AddDbContext<VehicleIdentityDbContext>(options => options.UseSqlServer(config.DbConnection));

            services
                .AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<VehicleIdentityDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
