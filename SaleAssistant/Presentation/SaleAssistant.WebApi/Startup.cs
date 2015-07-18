using System;
using System.Linq;
using System.Net.Http.Formatting;
using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using Core.OAuth.Identity;
using Newtonsoft.Json.Serialization;
using Owin;
using System.Web.Http;
using SaleAssistant.AutoMapper;

namespace SaleAssistant.WebApi
{
    public class Startup
    {
        private static IContainer Container { get; set; }

        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration httpConfig = new HttpConfiguration();

            app.ConfigureOAuthTokenGeneration();
            app.ConfigureOAuthTokenConsumption();
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            app.UseWebApi(httpConfig);

            ConfigureWebApi(httpConfig);

            AutofacRegister(httpConfig);
            DomainMappingRegister.Register();
        }

        private void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

        private void AutofacRegister(HttpConfiguration config)
        {
            ContainerBuilder builder = new ContainerBuilder();

            AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(ass => ass.GetTypes())
                .Where(type => type.IsSubclassOf(typeof(Autofac.Module)))
                .Select(type => (Autofac.Module)Activator.CreateInstance(type)).ToList()
                .ForEach(module => builder.RegisterModule(module));

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            Container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(Container);
        }
    }
}