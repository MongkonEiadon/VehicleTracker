using System;

using EventFlow.EntityFramework;

using Microsoft.EntityFrameworkCore;

using VehicleTracker.Infrastructure;

namespace EventStore {
    public class EventSourcingDbContextProvider : IDbContextProvider<EventSourcingDbContext>, IDisposable {
        private readonly DbContextOptions<EventSourcingDbContext> _options;

        public EventSourcingDbContextProvider(MiddlewareConfiguration configuration) {
            _options = new DbContextOptionsBuilder<EventSourcingDbContext>()
                .UseSqlServer(configuration.EventDbConnection)
                .Options;
        }


        public EventSourcingDbContext CreateContext() {
            var db = new EventSourcingDbContext(_options);
            db.Database.EnsureCreated();
            return db;
        }

        public void Dispose() {
        }
    }
}