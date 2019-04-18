using EventFlow.EntityFramework;

using Infrastructure.Configurations;

using Microsoft.EntityFrameworkCore;

namespace Vehicles.ReadStore {
    public class VehicleContextProvider : IDbContextProvider<VehicleContext> {
        private readonly DbContextOptions<VehicleContext> _options;

        public VehicleContextProvider(EnvironmentConfiguration configuration) {
            _options = new DbContextOptionsBuilder<VehicleContext>()
                .UseSqlServer(configuration.DbConnection)
                .Options;
        }

        public VehicleContext CreateContext() {
            var db = new VehicleContext(_options);
            db.Database.EnsureCreated();
            return db;
        }
    }
}