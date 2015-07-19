using Autofac;
using SaleAssistant.Data;

namespace SaleAssistant.DataAccess
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new ProductDA(c.Resolve<SaleAssistantDbContext>())).As<IProductDA>().SingleInstance();
            builder.Register(c => new UnitDA(c.Resolve<SaleAssistantDbContext>())).As<IUnitDA>().SingleInstance();
            builder.Register(c => new VendorDA(c.Resolve<SaleAssistantDbContext>())).As<IVendorDA>().SingleInstance();
            builder.Register(c => new CustomerDA(c.Resolve<SaleAssistantDbContext>())).As<ICustomerDA>().SingleInstance();
            builder.Register(c => new ProductPricingDA(c.Resolve<SaleAssistantDbContext>())).As<IProductPricingDA>().SingleInstance();
            builder.Register(c => new InventoryDA(c.Resolve<SaleAssistantDbContext>())).As<IInventoryDA>().SingleInstance();
            builder.Register(c => new InventoryItemDA(c.Resolve<SaleAssistantDbContext>())).As<IInventoryItemDA>().SingleInstance();
        }
    }
}
