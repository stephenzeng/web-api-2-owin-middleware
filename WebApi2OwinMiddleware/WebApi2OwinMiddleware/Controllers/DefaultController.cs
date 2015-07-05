using System;
using System.Web.Http;

namespace WebApi2OwinMiddleware.Controllers
{
    public class DefaultController : ApiController
    {
        public string Get()
        {
            return DateTime.Now.ToLongTimeString();
        }
    }
}


