using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Reflection;

namespace SaleAssistant.Data.Entities
{
    public class MigrationDbContext : DbContext
    {
        public MigrationDbContext() : base("SAConnection")
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Inventory> Inventories { get; set; }

        public DbSet<InventoryItem> InventoryItems { get; set; }

        public DbSet<ProductPricing> ProductPricings { get; set; }

        public DbSet<Unit> Units { get; set; }

        public DbSet<Vendor> Vendors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
