using System;
using System.Web.Http;

namespace WebApi2OwinMiddleware.Controllers
{
    public class DefaultController : ApiController
    {
        public DateTime Get()
        {
            return DateTime.Now;
        }

        [HttpPost]
        public string Post([FromBody]string name)
        {
            return string.Format("Hello {0}!", name);
        }
    }
}


