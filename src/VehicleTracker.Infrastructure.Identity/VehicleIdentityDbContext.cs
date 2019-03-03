using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace VehicleTracker.Infrastructure.Identity
{

    public class VehicleIdentityDbContext : IdentityDbContext {

        public VehicleIdentityDbContext(DbContextOptions<VehicleIdentityDbContext> options)
            : base(options) {
        }
    }
}
