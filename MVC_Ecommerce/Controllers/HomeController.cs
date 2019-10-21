using Ecommerce.BusinessLayer.Services.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Ecommerce.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            List<UserMasterBO> users = UserBusinessInstance.GetUser();
            return View(users);
        }

        [Authorize()]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}