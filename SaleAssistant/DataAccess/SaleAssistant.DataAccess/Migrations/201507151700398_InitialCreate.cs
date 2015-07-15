namespace SaleAssistant.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.InventoryDetails",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        InventoryId = c.Guid(nullable: false),
                        ProductId = c.Guid(nullable: false),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Inventories", t => t.InventoryId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.InventoryId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Code = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InventoryDetails", "ProductId", "dbo.Products");
            DropForeignKey("dbo.InventoryDetails", "InventoryId", "dbo.Inventories");
            DropIndex("dbo.InventoryDetails", new[] { "ProductId" });
            DropIndex("dbo.InventoryDetails", new[] { "InventoryId" });
            DropTable("dbo.Products");
            DropTable("dbo.InventoryDetails");
            DropTable("dbo.Inventories");
        }
    }
}
