using System.Data.Entity;
using SaleAssistant.Data.Entities;

namespace SaleAssistant.Data
{
    public class SaleAssistantDbContext : DbContext
    {
        protected IConfig Config { get; private set; }

        public SaleAssistantDbContext(IConfig config) : base(config.ConnectionString)
        {
            Config = config;
        }

        public DbSet<Product> Products { get; set; }

        //public System.Data.Entity.DbSet<Inventory> Inventories { get; set; }

        //public System.Data.Entity.DbSet<InventoryDetail> InventoryDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(Mapping.ProductMap).Assembly);
        }
    }
}
