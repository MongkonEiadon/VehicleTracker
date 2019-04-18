using System;

using EventFlow.EntityFramework;

using Infrastructure.Configurations;

using Microsoft.EntityFrameworkCore;

namespace EventStore.Middleware {
    public class EventSourcingDbContextProvider : IDbContextProvider<EventSourcingDbContext>, IDisposable {
        private readonly DbContextOptions<EventSourcingDbContext> _options;

        public EventSourcingDbContextProvider(EnvironmentConfiguration configuration) {
            _options = new DbContextOptionsBuilder<EventSourcingDbContext>()
                .UseSqlServer(configuration.EventSourcingConnection)
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