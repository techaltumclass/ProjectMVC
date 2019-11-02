using ECommerce.DataLayer;
using ECommerce.DataLayer.EDMX;
using MVC_Ecommerce.CustomFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Ecommerce.Controllers
{
    
    public class HomeController : Controller
    {
        ECommerceDataEntities _context = new ECommerceDataEntities();
        public ActionResult Index()
        {
            List<UserMaster> users = _context.UserMasters.ToList();
            return View(users);
        }

        [AuthorizePage((int)AspectEnums.RoleType.Admin)]
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