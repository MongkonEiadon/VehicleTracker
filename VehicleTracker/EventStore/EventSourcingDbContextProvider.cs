using System;
using EventFlow.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace EventStore
{
    public class EventSourcingDbContextProvider : IDbContextProvider<EventSourcingDbContext>, IDisposable
    {
        private readonly DbContextOptions<EventSourcingDbContext> _options;

        public EventSourcingDbContextProvider()
        {

            _options = new DbContextOptionsBuilder<EventSourcingDbContext>()
                .UseSqlServer("User ID=sa;Password=Pass@word;server=database_sql;Database=EventStore;Pooling=true;")
                .Options;
        }


        public EventSourcingDbContext CreateContext()
        {
            var db = new EventSourcingDbContext(_options);
            db.Database.EnsureCreated();
            return db;
        }

        public void Dispose()
        {
        }
    }
}