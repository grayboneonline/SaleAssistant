using System.Linq;
using System.Net.Http.Formatting;
using Core.OAuth.Identity;
using Newtonsoft.Json.Serialization;
using Owin;
using System.Web.Http;

namespace SaleAssistant.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration httpConfig = new HttpConfiguration();

            app.ConfigureOAuthTokenGeneration();
            app.ConfigureOAuthTokenConsumption();

            ConfigureWebApi(httpConfig);

            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            app.UseWebApi(httpConfig);
        }

        private void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }

    }
}