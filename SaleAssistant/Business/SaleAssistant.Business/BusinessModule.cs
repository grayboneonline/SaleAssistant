using Autofac;
using SaleAssistant.DataAccess;

namespace SaleAssistant.Business
{
    public class BusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new ProductManagement(c.Resolve<IProductDA>())).As<IProductManagement>().SingleInstance();
        }
    }
}
