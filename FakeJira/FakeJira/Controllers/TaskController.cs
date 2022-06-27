using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FakeJira.Models;
using FakeJira.ViewModels;
using FakeJiraDataLibrary.Models;

namespace FakeJira.Controllers
{
    public class TaskController : Controller
    {
        private ApplicationDbContext db;

        public TaskController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Task
        public ActionResult Index()
        {
            return View(db.Task.Include(t => t.Project).Include(t => t.User).ToList());
        }

        // GET: Task/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Task.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }

            var model = new TaskViewModel
            {
                Task = task,
                Projects = db.Project.ToList()
            };

            return View(model);
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            var project = db.Project.ToList();
            var model = new TaskViewModel
            {
                Projects = db.Project.ToList()
            };
            return View(model);
        }

        // POST: Task/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TaskViewModel taskVM)
        {
            var task = new Task
            {
                Title = taskVM.Task.Title,
                StatusId = taskVM.Task.StatusId,
                ProjectId = taskVM.Task.PriorityId,
                Project = taskVM.Task.Project,
                UserId = taskVM.Task.UserId,
                User = taskVM.Task.User,
                PriorityId = taskVM.Task.PriorityId,
                DateAdded = taskVM.Task.DateAdded,
                DateClosed = taskVM.Task.DateClosed
            };

            if (ModelState.IsValid)
            {
                db.Task.Add(task);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var model = new TaskViewModel
            {
                Task = task,
                Projects = db.Project.ToList()
            };
            taskVM.Projects = db.Project.ToList();
            return View(model);
        }

        // GET: Task/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Task task = db.Task.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }

            var model = new TaskViewModel
            {
                Task = task,
                Projects = db.Project.ToList()
            };

            return View(model);
        }

        // POST: Task/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TaskViewModel taskVM)
        {
            var task = new Task
            {
                Id = taskVM.Task.Id,
                Title = taskVM.Task.Title,
                StatusId = taskVM.Task.StatusId,
                ProjectId = taskVM.Task.PriorityId,
                Project = taskVM.Task.Project,
                UserId = taskVM.Task.UserId,
                User = taskVM.Task.User,
                PriorityId = taskVM.Task.PriorityId,
                DateAdded = taskVM.Task.DateAdded,
                DateClosed = taskVM.Task.DateClosed
            };

            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            taskVM.Projects = db.Project.ToList();
            return View(task);
        }

        // GET: Task/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Task task = db.Task.Find(id);
            if (task == null)
            {
                return HttpNotFound();
            }

            var model = new TaskViewModel
            {
                Task = task,
                Projects = db.Project.ToList()
            };
            return View(model);
        }

        // POST: Task/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Task task = db.Task.Find(id);
            db.Task.Remove(task);
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
