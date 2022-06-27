using FakeJira.Models;
using FakeJiraDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
            //List<UserModel> usersList = new List<UserModel>();
            //usersList = (from u in db.User
            //             select new UserModel
            //             {
            //                 Id = u.Id,
            //                 EmailAddress = u.EmailAddress,
            //                 FirstName = u.FirstName,
            //                 LastName = u.LastName,
            //                 Department = u.Department,
            //                 BusinessRole = u.BusinessRole,
            //                 Picture = u.Picture

            //             }

            //             ).ToList();
            return View(db.User.Include(t => t.Department).Include(t => t.BusinessRole).ToList());
            //return View(db.User.ToList());
        }
        public ActionResult BusinesRoleIndex()
        {
            return View(db.BusinessRole.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = db.User.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = db.User.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = db.User.Find(id);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            User user = db.User.Find(id);
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

    }
}