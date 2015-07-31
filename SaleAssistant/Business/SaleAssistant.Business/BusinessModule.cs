using Autofac;

namespace SaleAssistant.Business
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManagement>().As<IProductManagement>().SingleInstance();
            builder.RegisterType<UnitManagement>().As<IUnitManagement>().SingleInstance();
            builder.RegisterType<VendorManagement>().As<IVendorManagement>().SingleInstance();
            builder.RegisterType<CustomerManagement>().As<ICustomerManagement>().SingleInstance();
            builder.RegisterType<ProductPricingManagement>().As<IProductPricingManagement>().SingleInstance();
            builder.RegisterType<InventoryManagement>().As<IInventoryManagement>().SingleInstance();
            builder.RegisterType<InventoryItemManagement>().As<IInventoryItemManagement>().SingleInstance();
        }
    }
}
