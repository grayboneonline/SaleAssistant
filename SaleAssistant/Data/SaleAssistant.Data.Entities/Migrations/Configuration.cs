namespace SaleAssistant.Data.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MigrationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MigrationDbContext context)
        {
            context.Customers.AddOrUpdate(
                x => x.Id,
                new Customer { Id = 1, Name = "Farm TS", Status = Status.Active, IsDeleted = false },
                new Customer { Id = 2, Name = "Farm GK", Status = Status.Active, IsDeleted = false });

            context.Units.AddOrUpdate(
                x => x.Id,
                new Unit { Id = 1, Name = "Kg", Status = Status.Active, IsDeleted = false },
                new Unit { Id = 2, Name = "Bottle", Status = Status.Active, IsDeleted = false });

            context.Vendors.AddOrUpdate(
                x => x.Id,
                new Vendor { Id = 1, Name = "Pfizer", Status = Status.Active, IsDeleted = false },
                new Vendor { Id = 2, Name = "Bio", Status = Status.Active, IsDeleted = false });

            context.Inventories.AddOrUpdate(
                x => x.Id,
                new Inventory { Id = 1, Name = "Inventory", Status = Status.Active, IsDeleted = false });

            context.Products.AddOrUpdate(
                x => x.Id,
                new Product { Id = 1, Name = "Bio Speclin", Code = "B001", UnitId = 1, Status = Status.Active, IsDeleted = false },
                new Product { Id = 2, Name = "Bio Norxacin", Code = "B002", UnitId = 1, Status = Status.Active, IsDeleted = false },
                new Product { Id = 3, Name = "Bio Fer", Code = "N002", UnitId = 2, Status = Status.Active, IsDeleted = false },
                new Product { Id = 4, Name = "Bio Dexa", Code = "N003", UnitId = 2, Status = Status.Active, IsDeleted = false },
                new Product { Id = 5, Name = "Bio Sone", Code = "N001", UnitId = 2, Status = Status.Active, IsDeleted = false });

            context.ProductPricings.AddOrUpdate(
                x => x.Id,
                new ProductPricing { Id = 1, ProductId = 1, UnitPrice = 150000, Type = PricingType.Cost, EffectiveDate = new DateTime(2015, 07, 19), CreatedDate = new DateTime(2015, 07, 19) },
                new ProductPricing { Id = 2, ProductId = 1, UnitPrice = 230000, Type = PricingType.Sale, EffectiveDate = new DateTime(2015, 07, 19), CreatedDate = new DateTime(2015, 07, 19) },
                new ProductPricing { Id = 3, ProductId = 2, UnitPrice = 130000, Type = PricingType.Cost, EffectiveDate = new DateTime(2015, 07, 19), CreatedDate = new DateTime(2015, 07, 19) },
                new ProductPricing { Id = 4, ProductId = 2, UnitPrice = 185000, Type = PricingType.Sale, EffectiveDate = new DateTime(2015, 07, 19), CreatedDate = new DateTime(2015, 07, 19) },
                new ProductPricing { Id = 5, ProductId = 3, UnitPrice = 120000, Type = PricingType.Cost, EffectiveDate = new DateTime(2015, 07, 19), CreatedDate = new DateTime(2015, 07, 19) },
                new ProductPricing { Id = 6, ProductId = 3, UnitPrice = 135000, Type = PricingType.Sale, EffectiveDate = new DateTime(2015, 07, 19), CreatedDate = new DateTime(2015, 07, 19) },
                new ProductPricing { Id = 7, ProductId = 4, UnitPrice = 137000, Type = PricingType.Cost, EffectiveDate = new DateTime(2015, 07, 19), CreatedDate = new DateTime(2015, 07, 19) },
                new ProductPricing { Id = 8, ProductId = 4, UnitPrice = 205000, Type = PricingType.Sale, EffectiveDate = new DateTime(2015, 07, 19), CreatedDate = new DateTime(2015, 07, 19) },
                new ProductPricing { Id = 9, ProductId = 5, UnitPrice = 200000, Type = PricingType.Cost, EffectiveDate = new DateTime(2015, 07, 19), CreatedDate = new DateTime(2015, 07, 19) },
                new ProductPricing { Id = 10, ProductId = 5, UnitPrice = 2630000, Type = PricingType.Sale, EffectiveDate = new DateTime(2015, 07, 19), CreatedDate = new DateTime(2015, 07, 19) });

            context.InventoryItems.AddOrUpdate(
                x => x.Id,
                new InventoryItem { Id = 1, ProductId = 1, InventoryId = 1, Quantity = 5 },
                new InventoryItem { Id = 2, ProductId = 2, InventoryId = 1, Quantity = 15 },
                new InventoryItem { Id = 3, ProductId = 3, InventoryId = 1, Quantity = 25 },
                new InventoryItem { Id = 4, ProductId = 4, InventoryId = 1, Quantity = 30 },
                new InventoryItem { Id = 5, ProductId = 5, InventoryId = 1, Quantity = 10 });

            #region old
            //context.Customers.AddOrUpdate(
            //    x => x.Id,
            //    new Customer { Id = Guid.Parse("2DA40B0E-6B01-4025-84DC-6DC0BF13EAC0"), Name = "Farm TS", Status = Status.Active, IsDeleted = false },
            //    new Customer { Id = Guid.Parse("05730B2F-262F-4070-8A7F-AAF6464EEDC9"), Name = "Farm GK", Status = Status.Active, IsDeleted = false });

            //context.Units.AddOrUpdate(
            //    x => x.Id,
            //    new Unit { Id = Guid.Parse("85C65762-6DC7-4503-9271-74A43D2CA9AB"), Name = "Kg", Status = Status.Active, IsDeleted = false },
            //    new Unit { Id = Guid.Parse("29F4A4DA-F35B-4275-B4D8-DE63F5748C42"), Name = "Bottle", Status = Status.Active, IsDeleted = false });

            //context.Vendors.AddOrUpdate(
            //    x => x.Id,
            //    new Vendor { Id = Guid.Parse("089A3247-C91C-46F6-88F6-3F176FA173DD"), Name = "Pfizer", Status = Status.Active, IsDeleted = false },
            //    new Vendor { Id = Guid.Parse("36224766-91D2-4213-B0FF-4FD2D19462CB"), Name = "Bio", Status = Status.Active, IsDeleted = false });

            //context.Inventories.AddOrUpdate(
            //    x => x.Id,
            //    new Inventory { Id = Guid.Parse("3A8ED735-F959-4D67-9E57-F781B746E0E9"), Name = "Inventory", Status = Status.Active, IsDeleted = false });

            //context.Products.AddOrUpdate(
            //    x => x.Id,
            //    new Product { Id = Guid.Parse("E03A8954-2740-435B-B95C-327B02608011"), Name = "Bio Speclin", Code = "B001", UnitId = Guid.Parse("85C65762-6DC7-4503-9271-74A43D2CA9AB"), Status = Status.Active, IsDeleted = false },
            //    new Product { Id = Guid.Parse("B5E2C358-DF12-4BFB-B301-3D23B3258190"), Name = "Bio Norxacin", Code = "B002", UnitId = Guid.Parse("85C65762-6DC7-4503-9271-74A43D2CA9AB"), Status = Status.Active, IsDeleted = false },
            //    new Product { Id = Guid.Parse("198180AA-D148-4C0D-B85A-43D9C8C8C0BE"), Name = "Bio Fer", Code = "N002", UnitId = Guid.Parse("29F4A4DA-F35B-4275-B4D8-DE63F5748C42"), Status = Status.Active, IsDeleted = false },
            //    new Product { Id = Guid.Parse("57BF44DC-4743-409D-B3FD-622F7CBE512D"), Name = "Bio Dexa", Code = "N003", UnitId = Guid.Parse("29F4A4DA-F35B-4275-B4D8-DE63F5748C42"), Status = Status.Active, IsDeleted = false },
            //    new Product { Id = Guid.Parse("68745266-F2F7-446E-B702-A207D0F5D363"), Name = "Bio Sone", Code = "N001", UnitId = Guid.Parse("29F4A4DA-F35B-4275-B4D8-DE63F5748C42"), Status = Status.Active, IsDeleted = false });

            //context.ProductPricings.AddOrUpdate(
            //    x => x.Id,
            //    new ProductPricing { Id = Guid.Parse("F71E737B-473B-4C47-8068-00D3506A336E"), ProductId = Guid.Parse("E03A8954-2740-435B-B95C-327B02608011"), UnitPrice = 150000, Type = PricingType.Sale, EffectiveDate = new DateTime(2015, 07, 19), CreatedDate = new DateTime(2015, 07, 19) },
            //    new ProductPricing { Id = Guid.Parse("65FD1C45-F254-4978-8694-275BDA0A3B6C"), ProductId = Guid.Parse("B5E2C358-DF12-4BFB-B301-3D23B3258190"), UnitPrice = 230000, Type = PricingType.Sale, EffectiveDate = new DateTime(2015, 07, 19), CreatedDate = new DateTime(2015, 07, 19) },
            //    new ProductPricing { Id = Guid.Parse("6E7B0DD0-7EFA-43B6-9FB2-44943D7843D9"), ProductId = Guid.Parse("57BF44DC-4743-409D-B3FD-622F7CBE512D"), UnitPrice = 130000, Type = PricingType.Sale, EffectiveDate = new DateTime(2015, 07, 19), CreatedDate = new DateTime(2015, 07, 19) },
            //    new ProductPricing { Id = Guid.Parse("5A605BC2-562B-4FEE-8E51-49E07785E97A"), ProductId = Guid.Parse("198180AA-D148-4C0D-B85A-43D9C8C8C0BE"), UnitPrice = 185000, Type = PricingType.Cost, EffectiveDate = new DateTime(2015, 07, 19), CreatedDate = new DateTime(2015, 07, 19) },
            //    new ProductPricing { Id = Guid.Parse("A1006E17-89E2-4D30-A1D1-5B9379A5AFC1"), ProductId = Guid.Parse("68745266-F2F7-446E-B702-A207D0F5D363"), UnitPrice = 120000, Type = PricingType.Cost, EffectiveDate = new DateTime(2015, 07, 19), CreatedDate = new DateTime(2015, 07, 19) },
            //    new ProductPricing { Id = Guid.Parse("0536DA3A-80D3-41D5-BEF1-5DAFB20EFE4A"), ProductId = Guid.Parse("57BF44DC-4743-409D-B3FD-622F7CBE512D"), UnitPrice = 100000, Type = PricingType.Cost, EffectiveDate = new DateTime(2015, 07, 19), CreatedDate = new DateTime(2015, 07, 19) },
            //    new ProductPricing { Id = Guid.Parse("1D4DA207-EA40-409F-9D84-6B0252B10D0B"), ProductId = Guid.Parse("E03A8954-2740-435B-B95C-327B02608011"), UnitPrice = 137000, Type = PricingType.Cost, EffectiveDate = new DateTime(2015, 07, 19), CreatedDate = new DateTime(2015, 07, 19) },
            //    new ProductPricing { Id = Guid.Parse("8D70ADA8-02D3-46B1-B630-BB382FBE1BB2"), ProductId = Guid.Parse("198180AA-D148-4C0D-B85A-43D9C8C8C0BE"), UnitPrice = 205000, Type = PricingType.Sale, EffectiveDate = new DateTime(2015, 07, 19), CreatedDate = new DateTime(2015, 07, 19) },
            //    new ProductPricing { Id = Guid.Parse("9691509E-F22D-4297-BC45-BC4327F4D946"), ProductId = Guid.Parse("B5E2C358-DF12-4BFB-B301-3D23B3258190"), UnitPrice = 200000, Type = PricingType.Cost, EffectiveDate = new DateTime(2015, 07, 19), CreatedDate = new DateTime(2015, 07, 19) },
            //    new ProductPricing { Id = Guid.Parse("76739F31-9557-478D-948A-DE0016EEA301"), ProductId = Guid.Parse("68745266-F2F7-446E-B702-A207D0F5D363"), UnitPrice = 140000, Type = PricingType.Sale, EffectiveDate = new DateTime(2015, 07, 19), CreatedDate = new DateTime(2015, 07, 19) });

            //context.InventoryItems.AddOrUpdate(
            //    x => x.Id,
            //    new InventoryItem { Id = Guid.Parse("CF32D68C-BC8C-473B-B748-01F47445773B"), ProductId = Guid.Parse("68745266-F2F7-446E-B702-A207D0F5D363"), InventoryId = Guid.Parse("3A8ED735-F959-4D67-9E57-F781B746E0E9"), Quantity = 5},
            //    new InventoryItem { Id = Guid.Parse("AF445D79-9012-4A44-8875-09276034EBB1"), ProductId = Guid.Parse("B5E2C358-DF12-4BFB-B301-3D23B3258190"), InventoryId = Guid.Parse("3A8ED735-F959-4D67-9E57-F781B746E0E9"), Quantity = 15 },
            //    new InventoryItem { Id = Guid.Parse("910C171D-694C-4429-896C-5EA948EB7219"), ProductId = Guid.Parse("57BF44DC-4743-409D-B3FD-622F7CBE512D"), InventoryId = Guid.Parse("3A8ED735-F959-4D67-9E57-F781B746E0E9"), Quantity = 25 },
            //    new InventoryItem { Id = Guid.Parse("7F394D7D-B5CF-4287-B13E-A6CEACBBF761"), ProductId = Guid.Parse("198180AA-D148-4C0D-B85A-43D9C8C8C0BE"), InventoryId = Guid.Parse("3A8ED735-F959-4D67-9E57-F781B746E0E9"), Quantity = 30 },
            //    new InventoryItem { Id = Guid.Parse("B8A1F37E-A82F-4438-A974-FA7D6ED3617C"), ProductId = Guid.Parse("E03A8954-2740-435B-B95C-327B02608011"), InventoryId = Guid.Parse("3A8ED735-F959-4D67-9E57-F781B746E0E9"), Quantity = 10 });

            #endregion
        }
    }
}
