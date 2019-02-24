using System;
using Microsoft.EntityFrameworkCore;

namespace EFEventStore
{
    public class EventSourcingDbContext : DbContext
    {
        private readonly DbContextOptions<EventSourcingDbContext> _options;

        public EventSourcingDbContext(DbContextOptions<EventSourcingDbContext> options) : base(options)
        {
            _options = options;
        }
    }
    
}
