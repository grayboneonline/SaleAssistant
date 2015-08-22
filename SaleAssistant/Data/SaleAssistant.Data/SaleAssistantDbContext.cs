using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SaleAssistant.Data.Entities;

namespace SaleAssistant.Data
{
    public class SaleAssistantDbContext : DbContext
    {
        protected IConfig Config { get; private set; }

        public SaleAssistantDbContext(IConfig config) : base(config.ConnectionString)
        {
            Config = config;
            Database.SetInitializer<SaleAssistantDbContext>(null);
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
        }
    }
}
