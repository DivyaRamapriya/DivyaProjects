using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuizApi.Controllers
{
    [RoutePrefix("profile")]
    public class ProfileController : BaseController
    {
        [Route("current")]
        public HttpResponseMessage GetCurrent(int version)
        {
            ValidateApiVersionAndState(version);

            return Request.CreateResponse(HttpStatusCode.OK, new { Name = "Carlos", LastName="Martinez", DateOfBirth= new DateTime(1979, 9, 6) });
        }
    }
}
 