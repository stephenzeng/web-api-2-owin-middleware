using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using NUnit.Framework;
namespace WebApi2OwinMiddleware.Tests
{
    [TestFixture]
    public class the_default_contrller
    {
        [Test]
        public async Task http_get()
        {
            //arrange
            var httpConfig = new HttpConfiguration();
            WebApiConfig.Register(httpConfig);
            var url = "http://localhost/api/default";

            //act
            using (var httpServer = new HttpServer(httpConfig))
            using (var client = new HttpMessageInvoker(httpServer))
            {
                using (var request = new HttpRequestMessage(HttpMethod.Get, url))
                using (var response = await client.SendAsync(request, CancellationToken.None))
                {
                    var output = await response.Content.ReadAsAsync<DateTime>();

                    //assert
                    Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                    Assert.AreEqual(DateTime.Now.ToShortDateString(), output.ToShortDateString());
                }
            }
        }

        [Test]
        public async Task http_post()
        {
            //arrange
            var httpConfig = new HttpConfiguration();
            WebApiConfig.Register(httpConfig);
            var url = "http://localhost/api/default";

            //act
            using (var httpServer = new HttpServer(httpConfig))
            using (var client = new HttpMessageInvoker(httpServer))
            {
                using (var request = new HttpRequestMessage(HttpMethod.Post, url))
                {
                    request.Content = new ObjectContent<string>("Johnny", new JsonMediaTypeFormatter());
                    using (var response = await client.SendAsync(request, CancellationToken.None))
                    {
                        var output = await response.Content.ReadAsAsync<string>();

                        //assert
                        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
                        Assert.AreEqual("Hello Johnny!", output);
                    }
                }
            }
            
        }
    }
}
