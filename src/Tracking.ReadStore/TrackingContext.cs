using Microsoft.EntityFrameworkCore;

using Tracking.ReadStore.ReadModels;

namespace Tracking.ReadStore {
    public class TrackingContext : DbContext {
        public TrackingContext(DbContextOptions<TrackingContext> dbContextOptions)
            : base(dbContextOptions) {
        }

        public DbSet<LocationReadModel> VehicleLocations { get; set; }
    }
}