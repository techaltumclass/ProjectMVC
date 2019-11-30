using API_Ecommerce.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API_Ecommerce.Controllers
{
    //[JWTAuthenticationFilter]
    public class ValuesController : ApiController
    {

        public HttpResponseMessage Get()
        {

            var listOfbooks = GetAllBooks();

            return Request.CreateResponse(HttpStatusCode.OK, listOfbooks);
        }

        private List<Books> GetAllBooks()
        {
            List<Books> book = new List<Books>();
            book.Add(new Books { Id = 1, Name = "ABC Books" });
            book.Add(new Books { Id = 2, Name = "XYZ Books" });
            book.Add(new Books { Id = 3, Name = "DEF Books" });
            return book;
        }

        // GET api/values
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
