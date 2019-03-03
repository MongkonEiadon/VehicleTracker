using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace VehicleTracker.Infrastructure.Identity.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddVehicleAuthorizeService(this IServiceCollection services, IConfiguration config) {

            var identityConnection = config.GetValue<string>(Identifiers.IdentityConnection);

            services
                .AddDbContext<VehicleIdentityDbContext>(options => options.UseSqlServer(identityConnection));

            services
                .AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<VehicleIdentityDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }
    }
}
