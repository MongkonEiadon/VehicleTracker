using Microsoft.EntityFrameworkCore;

namespace Customer.ReadStore {
    public class CustomerContext : DbContext {
        public CustomerContext(DbContextOptions<CustomerContext> dbContextOptions)
            : base(dbContextOptions) {
        }

        public DbSet<CustomerReadModel> Customers { get; set; }
    }
}