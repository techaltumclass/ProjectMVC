using ECommerce.DataLayer.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Ecommerce.Controllers
{
    public class AccountController : Controller
    {
        ECommerceDataEntities _context;

        public AccountController()
        {
            _context = new ECommerceDataEntities();
        }

        public AccountController(ECommerceDataEntities context)
        {
            _context = context;
        }

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
            UserMaster user = _context.UserMasters.Where(x => x.cemailaddress == email && x.cpassword == password).FirstOrDefault();
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

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult ForgetPassword()
        {
            return View();
        }

        public ActionResult ResetPassword()
        {
            return View();
        }
    }
}