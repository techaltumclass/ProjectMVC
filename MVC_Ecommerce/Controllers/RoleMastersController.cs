//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using MVC_Ecommerce.CustomFilters;
//using MVC_Ecommerce.ViewModels;

//namespace MVC_Ecommerce.Controllers
//{
//    //[AuthorizePage((int)AspectEnums.RoleType.Admin)]
//    public class RoleMastersController : BaseController
//    {
//        // GET: RoleMasters
//        public ActionResult Index()
//        {
//            RolesModel model = new RolesModel();
//            model.roles = UserBusinessInstance.RoleMasters.Include(r => r.UserMaster).ToList();
//            model.userRoles = UserBusinessInstance.UserRoles.ToList();
//            return View(model);
//        }

//        // GET: RoleMasters/Details/5
//        public ActionResult Details(byte? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            RoleMaster roleMaster = UserBusinessInstance.RoleMasters.Find(id);
//            if (roleMaster == null)
//            {
//                return HttpNotFound();
//            }
//            return View(roleMaster);
//        }

//        // GET: RoleMasters/Create
//        public ActionResult Create()
//        {
//            ViewBag.CreatedBy = new SelectList(UserBusinessInstance.UserMasters, "UserID", "cfirstname");
//            return View();
//        }

//        // POST: RoleMasters/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create([Bind(Include = "RoleID,RollName,RollType,RollDescription,CreatedBy,CreatedOn")] RoleMaster roleMaster)
//        {
//            if (ModelState.IsValid)
//            {
//                UserBusinessInstance.RoleMasters.Add(roleMaster);
//                UserBusinessInstance.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.CreatedBy = new SelectList(UserBusinessInstance.UserMasters, "UserID", "cfirstname", roleMaster.CreatedBy);
//            return View(roleMaster);
//        }

//        public JsonResult GetUsersByRole(int Id)
//        {
//            UserBusinessInstance.Configuration.ProxyCreationEnabled = false;
//            var users = UserBusinessInstance.UserRoles.Where(x=>x.RoleID == Id).ToList();
//            return Json(users, JsonRequestBehavior.AllowGet);
//        }

//        // GET: RoleMasters/Create
//        public ActionResult CreateUserRole()
//        {
//            ViewBag.RoleID = new SelectList(UserBusinessInstance.RoleMasters, "RoleID", "RollName");
//            ViewBag.UserID = new SelectList(UserBusinessInstance.UserMasters, "UserID", "cfirstname");
//            return View();
//        }

//        // POST: RoleMasters/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult CreateUserRole(UserRole userRole)
//        {
//            if (ModelState.IsValid)
//            {
//                UserBusinessInstance.UserRoles.Add(userRole);
//                UserBusinessInstance.SaveChanges();
//                return RedirectToAction("Index");
//            }

//            ViewBag.RoleID = new SelectList(UserBusinessInstance.RoleMasters, "RoleID", "RollName");
//            ViewBag.UserID = new SelectList(UserBusinessInstance.UserMasters, "UserID", "cfirstname");

//            return View(userRole);
//        }

//        // GET: RoleMasters/Edit/5
//        public ActionResult Edit(byte? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            RoleMaster roleMaster = UserBusinessInstance.RoleMasters.Find(id);
//            if (roleMaster == null)
//            {
//                return HttpNotFound();
//            }
//            ViewBag.CreatedBy = new SelectList(UserBusinessInstance.UserMasters, "UserID", "cfirstname", roleMaster.CreatedBy);
//            return View(roleMaster);
//        }

//        // POST: RoleMasters/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Edit([Bind(Include = "RoleID,RollName,RollType,RollDescription,CreatedBy,CreatedOn")] RoleMaster roleMaster)
//        {
//            if (ModelState.IsValid)
//            {
//                UserBusinessInstance.Entry(roleMaster).State = EntityState.Modified;
//                UserBusinessInstance.SaveChanges();
//                return RedirectToAction("Index");
//            }
//            ViewBag.CreatedBy = new SelectList(UserBusinessInstance.UserMasters, "UserID", "cfirstname", roleMaster.CreatedBy);
//            return View(roleMaster);
//        }

//        // GET: RoleMasters/Delete/5
//        public ActionResult Delete(byte? id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            RoleMaster roleMaster = UserBusinessInstance.RoleMasters.Find(id);
//            if (roleMaster == null)
//            {
//                return HttpNotFound();
//            }
//            return View(roleMaster);
//        }

//        // POST: RoleMasters/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public ActionResult DeleteConfirmed(byte id)
//        {
//            RoleMaster roleMaster = UserBusinessInstance.RoleMasters.Find(id);
//            UserBusinessInstance.RoleMasters.Remove(roleMaster);
//            UserBusinessInstance.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                UserBusinessInstance.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
