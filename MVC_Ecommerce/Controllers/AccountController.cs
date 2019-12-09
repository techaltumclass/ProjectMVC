
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
        UserMasterBO USERPROFILE = new UserMasterBO();


        [HttpGet]
        [Route("Login-User")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            UserMasterBO user = UserBusinessInstance.UserLogin(email, password); //.Where(x => x.cemailaddress == email && x.cpassword == password).FirstOrDefault();
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
        public ActionResult Register(UserMasterBO user)
        {
            bool isSuccess = false;
            if (ModelState.IsValid)
            {
                isSuccess = UserBusinessInstance.SubmitUser(user) > 0 ? true : false;
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

            int roleID = UserBusinessInstance.GetUserRoleID(userID);
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