using FakeJira.Models;
using FakeJiraDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FakeJira.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private ApplicationDbContext db;

        public UserController()
        {
            db = new ApplicationDbContext();
        }
        // GET: User
        public ActionResult Index()
        {
            return View(db.User.ToList());
        }
        public ActionResult CreateBusinessRole()
        {
            return View();
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBusinessRole(BusinessRole businessRole)
        {
            if (ModelState.IsValid)
            {
                db.BusinessRole.Add(businessRole);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult CreateDepartment()
        {
            return View();
        }
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDepartment(Department newDepartment)
        {
            if (ModelState.IsValid)
            {
                db.Department.Add(newDepartment);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

    }
}