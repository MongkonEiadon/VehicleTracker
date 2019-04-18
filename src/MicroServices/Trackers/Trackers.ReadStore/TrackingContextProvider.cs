using EventFlow.EntityFramework;

using Infrastructure.Configurations;

using Microsoft.EntityFrameworkCore;


namespace Trackers.ReadStore {
    public class TrackingContextProvider : IDbContextProvider<TrackingContext> {
        private readonly DbContextOptions<TrackingContext> _options;

        public TrackingContextProvider(EnvironmentConfiguration configuration) {
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