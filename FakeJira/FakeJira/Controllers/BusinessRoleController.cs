using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FakeJira.Models;
using FakeJiraDataLibrary.Models;

namespace FakeJira.Controllers
{
    public class BusinessRoleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BusinessRole
        public ActionResult Index()
        {
            return View(db.BusinessRole.ToList());
        }

        // GET: BusinessRole/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessRole businessRole = db.BusinessRole.Find(id);
            if (businessRole == null)
            {
                return HttpNotFound();
            }
            return View(businessRole);
        }

        // GET: BusinessRole/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Manager,ParentManagerId")] BusinessRole businessRole)
        {
            if (ModelState.IsValid)
            {
                db.BusinessRole.Add(businessRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(businessRole);
        }

        // GET: BusinessRole/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessRole businessRole = db.BusinessRole.Find(id);
            if (businessRole == null)
            {
                return HttpNotFound();
            }
            return View(businessRole);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Manager,ParentManagerId")] BusinessRole businessRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(businessRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(businessRole);
        }

        // GET: BusinessRole/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BusinessRole businessRole = db.BusinessRole.Find(id);
            if (businessRole == null)
            {
                return HttpNotFound();
            }
            return View(businessRole);
        }

        // POST: BusinessRole/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BusinessRole businessRole = db.BusinessRole.Find(id);
            db.BusinessRole.Remove(businessRole);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
