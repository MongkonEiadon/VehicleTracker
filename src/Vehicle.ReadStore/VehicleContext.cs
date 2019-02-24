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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("User ID=sa;Password=Pass@word;server=localhost,5553;Database=Vehicle;Pooling=true;");

        }
    }
}