using EventFlow.EntityFramework;

using Microsoft.EntityFrameworkCore;

using VehicleTracker.Infrastructure;

namespace Tracking.ReadStore {
    public class TrackingContextProvider : IDbContextProvider<TrackingContext> {
        private readonly DbContextOptions<TrackingContext> _options;

        public TrackingContextProvider(ServiceConfiguration configuration) {
            _options = new DbContextOptionsBuilder<TrackingContext>()
                .UseSqlServer(configuration.DbConnection)
                .Options;
        }

        public TrackingContext CreateContext() {
            var db = new TrackingContext(_options);
            db.Database.EnsureCreated();
            return db;
        }
    }
}