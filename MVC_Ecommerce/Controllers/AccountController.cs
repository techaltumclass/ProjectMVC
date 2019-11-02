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
        UserMaster USERPROFILE = new UserMaster();

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
                USERPROFILE = user;
                WelcomeUser(user.UserID);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Message = "You are not authorized to login, please contact your administrator";
                Response.Redirect("~/Account/UnAuthorizedUser", true);
                return View("UnAuthorizedUser", "Account");
            }

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

        public ActionResult UnAuthorizedUser()
        {
            return View();
        }




        private void WelcomeUser(int userID)
        {
            
            CreateFreshSession();

            int roleID = Convert.ToInt32(_context.UserRoles.Where(x => x.UserID == userID).FirstOrDefault().RoleID);
            bool IsAdmin = roleID == 1 ? true : false;
            HttpContext.Session["SESSION_USER_ID"] = userID;
            HttpContext.Session["SESSION_PROFILE_KEY"] = USERPROFILE;
            HttpContext.Session["SESSION_ROLE_ID"] = roleID;
            HttpContext.Session["SESSION_ADMIN"] = IsAdmin ? "1" : "0";
        }

        private void CreateFreshSession()
        {
            Session.Clear();

            // createa a new GUID and save into the session
            string guid = Guid.NewGuid().ToString();
            HttpContext.Session["AuthToken"] = guid;
            // now create a new cookie with this guid value
            HttpContext.Response.Cookies.Add(new HttpCookie(CookieVariables.AuthToken, guid));
        }

        public static class CookieVariables
        {
            public const string AuthToken = "AuthToken";
        }

    }
}