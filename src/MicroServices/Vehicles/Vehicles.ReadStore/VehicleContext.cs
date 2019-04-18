using Microsoft.EntityFrameworkCore;

namespace Vehicles.ReadStore {
    public class VehicleContext : DbContext {
        public VehicleContext(DbContextOptions<VehicleContext> dbContextOptions)
            : base(dbContextOptions) {
        }

        public DbSet<VehicleReadModel> Vehicles { get; set; }

    }
}