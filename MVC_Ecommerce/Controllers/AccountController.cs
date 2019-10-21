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

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserMaster user)
        {
            bool isSuccess = false;
            if (ModelState.IsValid)
            {
                _context.UserMasters.Add(user);
                isSuccess = _context.SaveChanges() > 0 ? true : false;
            }
            else
                ViewBag.Message = "Model Validation error";

            int myuser;
            if (isSuccess)
            {
                myuser = user.UserID;
                ModelState.Clear();
                ViewBag.Message = "Success!";
            }
            else
                ViewBag.Message = "Fail";

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