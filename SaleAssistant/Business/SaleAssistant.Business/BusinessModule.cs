using Autofac;
using SaleAssistant.DataAccess;

namespace SaleAssistant.Business
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new ProductManagement(c.Resolve<IProductDA>())).As<IProductManagement>().SingleInstance();
            builder.Register(c => new UnitManagement(c.Resolve<IUnitDA>())).As<IUnitManagement>().SingleInstance();
            builder.Register(c => new VendorManagement(c.Resolve<IVendorDA>())).As<IVendorManagement>().SingleInstance();
            builder.Register(c => new CustomerManagement(c.Resolve<ICustomerDA>())).As<ICustomerManagement>().SingleInstance();
            builder.Register(c => new ProductPricingManagement(c.Resolve<IProductPricingDA>())).As<IProductPricingManagement>().SingleInstance();
            builder.Register(c => new InventoryManagement(c.Resolve<IInventoryDA>())).As<IInventoryManagement>().SingleInstance();
            builder.Register(c => new InventoryItemManagement(c.Resolve<IInventoryItemDA>())).As<IInventoryItemManagement>().SingleInstance();
        }
    }
}
