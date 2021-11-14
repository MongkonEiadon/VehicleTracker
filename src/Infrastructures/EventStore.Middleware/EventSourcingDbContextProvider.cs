using System;

using EventFlow.EntityFramework;

using Infrastructure.Configurations;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EventStore.Middleware {
    public class EventSourcingDbContextProvider : IDbContextProvider<EventSourcingDbContext>, IDisposable {

        private readonly IConfiguration _configuration;

        private DbContextOptions<EventSourcingDbContext> _options;

        public EventSourcingDbContextProvider(IConfiguration configuration) {
            _configuration = configuration;
        }


        public EventSourcingDbContext CreateContext() {
            if(_options == null)
                _options = new DbContextOptionsBuilder<EventSourcingDbContext>()
                    .UseSqlServer(EnvironmentConfiguration.Bind(_configuration).EventSourcingConnection)
                    .Options;
            
            var db = new EventSourcingDbContext(_options);
            db.Database.EnsureCreated();
            return db;
        }

        public void Dispose() {
        }
    }
}