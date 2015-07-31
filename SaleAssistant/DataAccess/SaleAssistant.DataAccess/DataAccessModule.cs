using Autofac;

namespace SaleAssistant.DataAccess
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductDA>().As<IProductDA>().SingleInstance();
            builder.RegisterType<UnitDA>().As<IUnitDA>().SingleInstance();
            builder.RegisterType<VendorDA>().As<IVendorDA>().SingleInstance();
            builder.RegisterType<CustomerDA>().As<ICustomerDA>().SingleInstance();
            builder.RegisterType<ProductPricingDA>().As<IProductPricingDA>().SingleInstance();
            builder.RegisterType<InventoryDA>().As<IInventoryDA>().SingleInstance();
            builder.RegisterType<InventoryItemDA>().As<IInventoryItemDA>().SingleInstance();
        }
    }
}
