using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuizApi.Controllers
{
    [RoutePrefix("user")]
    public class UserController : BaseController
    {
        [Route("table")]
        public HttpResponseMessage Gettable(int version)
        {
            ValidateApiVersionAndState(version); 

            return Request.CreateResponse(HttpStatusCode.OK, "" );
        }

        [Route("search")]
        [HttpGet]
        public HttpResponseMessage search(string version)
        {
            //ValidateApiVersionAndState(version);

            return Request.CreateResponse(HttpStatusCode.OK, "test");
        }

       
    }
}
