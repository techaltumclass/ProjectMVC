﻿using ECommerce.DataLayer.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC_Ecommerce.Controllers
{
    [RoutePrefix("test")]
    public class ValuesController : ApiController
    {
        ECommerceDataEntities _context = new ECommerceDataEntities();

        // GET api/values
        [Route("values")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("Hello")]
        [Authorize]
        [HttpGet]
        public HttpResponseMessage HelloWorld()
        {
            return Request.CreateResponse(HttpStatusCode.OK, "Hello User");
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [Route("post")]
        public void Post([FromBody]string value)
        {

        }

        [HttpGet]
        [Route("employees")]
        public List<UserMaster> GetEmployees()
        {
            return _context.UserMasters.ToList();
        }

        [HttpPut]
        [Route("add-employee")]
        public HttpResponseMessage AddEmployee(UserMaster user)
        {
            try
            {
               
                _context.UserMasters.Add(user);
                _context.SaveChanges();
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Error occured please check.");
            }
           
         
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
