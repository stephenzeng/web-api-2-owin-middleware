using System.Web.Http;
using Microsoft.Owin;
using Owin;
using WebApi2OwinMiddleware;

[assembly: OwinStartup(typeof(Startup))]

namespace WebApi2OwinMiddleware
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();
            WebApiConfig.Register(config);
            app.UseWebApi(config);
        }
    }
}
