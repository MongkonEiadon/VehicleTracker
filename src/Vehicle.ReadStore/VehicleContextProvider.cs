using EventFlow.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace Vehicle.ReadStore
{
    public class VehicleContextProvider : IDbContextProvider<VehicleContext>
    {
        private readonly DbContextOptions<VehicleContext> _options;
        public VehicleContextProvider()
        {
            _options = new DbContextOptionsBuilder<VehicleContext>()
                .UseSqlServer("User ID=sa;Password=Pass@word;server=localhost,5553;Database=Vehicle;Pooling=true;")
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