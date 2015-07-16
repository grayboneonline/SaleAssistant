using System.Data.Entity;
using Core.Data;
using SaleAssistant.DataAccess.Entities;

namespace SaleAssistant.DataAccess
{
    public class SaleAssistantDbContext : Core.Data.EF.DbContext
    {
        public SaleAssistantDbContext(IConfig config) : base(config) { }

        public DbSet<Product> Products { get; set; }

        //public System.Data.Entity.DbSet<Inventory> Inventories { get; set; }

        //public System.Data.Entity.DbSet<InventoryDetail> InventoryDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.AddFromAssembly(typeof(Mapping.ProductMap).Assembly);
        }
    }
}
