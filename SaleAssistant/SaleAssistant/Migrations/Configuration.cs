namespace SaleAssistant.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SaleAssistant.Models.SaleAssistantContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SaleAssistant.Models.SaleAssistantContext context)
        {
            context.Products.AddOrUpdate(x => x.Id,
                new Product { Id = new Guid("E03A8954-2740-435B-B95C-327B02608011"), Name = "Bio Speclin", Code = "B001", Status = ProductStatus.Active },
                new Product { Id = new Guid("68745266-F2F7-446E-B702-A207D0F5D363"), Name = "Bio Sone", Code = "N001", Status = ProductStatus.Active },
                new Product { Id = new Guid("B5E2C358-DF12-4BFB-B301-3D23B3258190"), Name = "Bio Norxacin", Code = "B002", Status = ProductStatus.Active },
                new Product { Id = new Guid("198180AA-D148-4C0D-B85A-43D9C8C8C0BE"), Name = "Bio Fer", Code = "N002", Status = ProductStatus.Active },
                new Product { Id = new Guid("57BF44DC-4743-409D-B3FD-622F7CBE512D"), Name = "Bio Dexa", Code = "N003", Status = ProductStatus.Active }
                );

            context.Inventories.AddOrUpdate(x => x.Id,
                new Inventory { Id = new Guid("3A8ED735-F959-4D67-9E57-F781B746E0E9"), Name = "Store GK", Status = InventoryStatus.Active },
                new Inventory { Id = new Guid("29A39E35-9934-492D-A2A8-D84D48645AE8"), Name = "Store TS", Status = InventoryStatus.Active });

            context.InventoryDetails.AddOrUpdate(x => x.Id,
                new InventoryDetail { Id = new Guid("B8A1F37E-A82F-4438-A974-FA7D6ED3617C"), InventoryId = new Guid("3A8ED735-F959-4D67-9E57-F781B746E0E9"), ProductId = new Guid("E03A8954-2740-435B-B95C-327B02608011"), Quantity = 10M },
                new InventoryDetail { Id = new Guid("AF445D79-9012-4A44-8875-09276034EBB1"), InventoryId = new Guid("3A8ED735-F959-4D67-9E57-F781B746E0E9"), ProductId = new Guid("B5E2C358-DF12-4BFB-B301-3D23B3258190"), Quantity = 15M },
                new InventoryDetail { Id = new Guid("CF32D68C-BC8C-473B-B748-01F47445773B"), InventoryId = new Guid("29A39E35-9934-492D-A2A8-D84D48645AE8"), ProductId = new Guid("68745266-F2F7-446E-B702-A207D0F5D363"), Quantity = 5M },
                new InventoryDetail { Id = new Guid("7F394D7D-B5CF-4287-B13E-A6CEACBBF761"), InventoryId = new Guid("29A39E35-9934-492D-A2A8-D84D48645AE8"), ProductId = new Guid("198180AA-D148-4C0D-B85A-43D9C8C8C0BE"), Quantity = 30M },
                new InventoryDetail { Id = new Guid("910C171D-694C-4429-896C-5EA948EB7219"), InventoryId = new Guid("29A39E35-9934-492D-A2A8-D84D48645AE8"), ProductId = new Guid("57BF44DC-4743-409D-B3FD-622F7CBE512D"), Quantity = 25M });
        }
    }
}
