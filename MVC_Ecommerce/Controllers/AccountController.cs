
using Ecommerce.BusinessLayer;
using Ecommerce.BusinessLayer.Services;
using Ecommerce.BusinessLayer.Services.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Ecommerce.Controllers
{
    public class AccountController : BaseController
    {
        //ECommerceDataEntities _context;

        //public AccountController()
        //{
        //    _context = new ECommerceDataEntities();
        //}

        //public AccountController(ECommerceDataEntities context)
        //{
        //    _context = context;
        //}

        [HttpGet]
        [Route("Login-User")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [Route("Login-User")]
        public ActionResult Login(string email, string password)
        {
            UserMasterBO user = UserBusinessInstance.UserLogin(email, password);
            if (user != null)
            {
                ViewBag.LoginMessage = "User Logged In successfully!";
            }
            else
            {
                ViewBag.LoginMessage = "User Log in failed!";
            }

            return View();
        }

        //public ActionResult Register()
        //{
        //    return View();
        //}

        //public ActionResult ForgetPassword()
        //{
        //    return View();
        //}

        //public ActionResult ResetPassword()
        //{
        //    return View();
        //}
    }
}