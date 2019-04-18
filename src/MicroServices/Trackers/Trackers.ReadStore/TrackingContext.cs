using Microsoft.EntityFrameworkCore;

using Trackers.ReadStore.ReadModels;

namespace Trackers.ReadStore {
    public class TrackingContext : DbContext {
        public TrackingContext(DbContextOptions<TrackingContext> dbContextOptions)
            : base(dbContextOptions) {
        }

        public DbSet<LocationReadModel> VehicleLocations { get; set; }
    }
}