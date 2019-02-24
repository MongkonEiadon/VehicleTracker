using EventFlow.EntityFramework.Extensions;
using Microsoft.EntityFrameworkCore;

namespace EventStore
{
    public class EventSourcingDbContext : DbContext
    {
        private readonly DbContextOptions<EventSourcingDbContext> _options;

        public EventSourcingDbContext(DbContextOptions<EventSourcingDbContext> options) : base(options)
        {
            _options = options;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .AddEventFlowEvents()
                .AddEventFlowSnapshots();
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("User ID=sa;Password=Pass@word;server=localhost,5553;Database=EventStore;Pooling=true;");
        //}
    }
}
