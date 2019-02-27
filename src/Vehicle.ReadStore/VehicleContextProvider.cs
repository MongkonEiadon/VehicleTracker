using EventFlow.EntityFramework;
using Microsoft.EntityFrameworkCore;
using VehicleTracker.Infrastructure;

namespace Vehicle.ReadStore
{
    public class VehicleContextProvider : IDbContextProvider<VehicleContext>
    {
        private readonly DbContextOptions<VehicleContext> _options;
        public VehicleContextProvider(ServiceConfiguration configuration)
        {
            _options = new DbContextOptionsBuilder<VehicleContext>()
                .UseSqlServer(configuration.DbConnection)
                .Options;
        }

        public VehicleContext CreateContext()
        {
            var db = new VehicleContext(_options);
            db.Database.EnsureCreated();
            return db;
        }
    }
}