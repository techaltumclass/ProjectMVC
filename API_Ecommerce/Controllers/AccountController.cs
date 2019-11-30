using API_Ecommerce.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Ecommerce.Controllers
{
    public class AccountController : ApiController
    {
        [HttpPost]
        public HttpResponseMessage LoginDemo(string userName, string password)
        {

            AuthenticationModule authentication = new AuthenticationModule();
            string token = authentication.GenerateTokenForUser("UserName", 1001);
            return Request.CreateResponse(HttpStatusCode.OK, token, Configuration.Formatters.JsonFormatter);

        }
    }
}
