using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SaleAssistant.AutoMapper;
using SaleAssistant.Business;
using SaleAssistant.Controllers;
using SaleAssistant.Data;
using SaleAssistant.DataAccess;

namespace SaleAssistant
{
    public class WebApiApplication : HttpApplication
    {
        private static IContainer Container { get; set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutofacRegister();

            DomainMappingRegister.Register();
        }

        private void AutofacRegister()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.Register<IConfig>(c => Config.DevEnvironment).SingleInstance();
            builder.RegisterType<SaleAssistantDbContext>().AsSelf().SingleInstance();
            builder.RegisterType<ProductDA>().AsImplementedInterfaces().SingleInstance();
            builder.RegisterType<ProductManagement>().AsImplementedInterfaces().SingleInstance();

            HttpConfiguration config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            // OPTIONAL: Register the Autofac filter provider.
            //builder.RegisterWebApiFilterProvider(config);



            Container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }
    }
}
