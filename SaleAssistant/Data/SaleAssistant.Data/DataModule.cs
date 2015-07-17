using Autofac;

namespace SaleAssistant.Data
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => Config.DevEnvironment).As<IConfig>().SingleInstance();
            builder.Register(c => new SaleAssistantDbContext(c.Resolve<IConfig>())).AsSelf().SingleInstance();
        }
    }
}
