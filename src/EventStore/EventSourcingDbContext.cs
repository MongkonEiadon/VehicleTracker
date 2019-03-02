using EventFlow.EntityFramework.Extensions;

using Microsoft.EntityFrameworkCore;

namespace EventStore {
    public class EventSourcingDbContext : DbContext {
        private readonly DbContextOptions<EventSourcingDbContext> _options;

        public EventSourcingDbContext(DbContextOptions<EventSourcingDbContext> options) : base(options) {
            _options = options;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder
                .AddEventFlowEvents()
                .AddEventFlowSnapshots();
        }

    }
}