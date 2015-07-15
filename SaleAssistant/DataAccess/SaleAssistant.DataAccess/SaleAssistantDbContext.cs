using System;
using Core.DataAccess;
using SaleAssistant.DataAccess.Entities;

namespace SaleAssistant.DataAccess
{
    public class SaleAssistantDbContext : DbContext
    {
        public SaleAssistantDbContext() : base(Config.DevEnvironment) { }

        public System.Data.Entity.DbSet<Product> Products { get; set; }

        public System.Data.Entity.DbSet<Inventory> Inventories { get; set; }

        public System.Data.Entity.DbSet<InventoryDetail> InventoryDetails { get; set; }
    
    }
}
