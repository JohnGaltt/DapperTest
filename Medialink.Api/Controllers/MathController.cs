using MediaLink.Lib;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Medialink.Api.Controllers
{
    public class MathController : ApiController
    {
        private readonly MathWebClient _mathWebClient;

        public MathController(MathWebClient mathWebClient)
        {
            _mathWebClient = mathWebClient;
        }
        [HttpGet]
        public HttpResponseMessage Index()
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            //response.Content = new StringContent(Convert.ToString(a + b));
            var test = _mathWebClient.Add(2, 3);
            return response;
        }

        public HttpResponseMessage Add(int a, int b)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(Convert.ToString(a + b));

            return response;
        }

        public HttpResponseMessage Multiply(int a, int b)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(Convert.ToString(a * b));

            return response;
        }

        public HttpResponseMessage Divide(int a, int b)
        {
            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StringContent(Convert.ToString(a / b));

            return response;
        }
    }
}
