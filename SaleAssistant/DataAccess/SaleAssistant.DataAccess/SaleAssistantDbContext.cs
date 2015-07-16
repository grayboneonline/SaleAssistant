using System;
using System.Data.Entity;
using SaleAssistant.DataAccess.Entities;
using System.Reflection;

namespace SaleAssistant.DataAccess
{
    public class SaleAssistantDbContext : Core.Data.EF.DbContext
    {
        public SaleAssistantDbContext() : base(Config.DevEnvironment) { }

        public DbSet<Product> Products { get; set; }

        //public System.Data.Entity.DbSet<Inventory> Inventories { get; set; }

        //public System.Data.Entity.DbSet<InventoryDetail> InventoryDetails { get; set; }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.AddFromAssembly(typeof(SaleAssistant.DataAccess.Mapping.ProductMap).Assembly);
        }
    }
}
