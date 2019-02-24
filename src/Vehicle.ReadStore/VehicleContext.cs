using Microsoft.EntityFrameworkCore;

namespace Vehicle.ReadStore
{
    public class VehicleContext : DbContext
    {
        public DbSet<VehicleReadModel> Vehicles { get; set; }

        public VehicleContext(DbContextOptions<VehicleContext> dbContextOptions)
            :base(dbContextOptions)
        {

        }
    }
}