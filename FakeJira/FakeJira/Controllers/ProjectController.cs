using FakeJira.Models;
using FakeJiraDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FakeJira.Controllers
{
    public class ProjectController : Controller
    {
        private ApplicationDbContext db;

        public ProjectController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Project
        public ActionResult Index()
        {
            return View(db.Project.ToList());
        }

        // CREATE: Project
        // GET
        public ActionResult Create()
        {
            return View();
        }

        // CREATE: Project
        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Project project)
        {
            if (ModelState.IsValid)
            {
                db.Project.Add(project);
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