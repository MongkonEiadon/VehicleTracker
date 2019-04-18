using EventFlow.EntityFramework;

using Microsoft.EntityFrameworkCore;

using VehicleTracker.Infrastructure;
using VehicleTracker.Infrastructure.Configurations;

namespace Customer.ReadStore {
    public class CustomerContextProvider : IDbContextProvider<CustomerContext> {
        private readonly DbContextOptions<CustomerContext> _options;

        public CustomerContextProvider(EnvironmentConfiguration configuration) {
            _options = new DbContextOptionsBuilder<CustomerContext>()
                .UseSqlServer(configuration.DbConnection)
                .Options;
        }

        public CustomerContext CreateContext() {
            var db = new CustomerContext(_options);
            db.Database.EnsureCreated();
            return db;
        }
    }
}