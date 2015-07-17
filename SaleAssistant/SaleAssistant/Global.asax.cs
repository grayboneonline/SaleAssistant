using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Autofac.Core;
using Autofac.Integration.WebApi;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using SaleAssistant.AutoMapper;
using SaleAssistant.Business;
using SaleAssistant.Data;
using SaleAssistant.DataAccess;
using WebGrease.Css.Extensions;

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

            AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(ass => ass.GetTypes())
                .Where(type => type.IsSubclassOf(typeof(Autofac.Module)))
                .Select(type => (Autofac.Module)Activator.CreateInstance(type))
                .ForEach(module => builder.RegisterModule(module));

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            HttpConfiguration config = GlobalConfiguration.Configuration;

            // OPTIONAL: Register the Autofac filter provider.
            //builder.RegisterWebApiFilterProvider(config);

            Container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }
    }
}
