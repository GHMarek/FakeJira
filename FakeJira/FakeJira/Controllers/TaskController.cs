﻿using System;
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
using Microsoft.AspNet.Identity;
using FakeJiraDataLibrary.Processors;

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
            return View(db.Task.Include(t => t.Project)
                .Include(t => t.User)
                .Include(t => t.TaskStatus)
                .Include(t => t.TaskPriority)
                .ToList());
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
                Projects = db.Project.ToList(),
                Users = db.User.ToList()
            };

            return View(model);
        }

        // GET: Task/Create
        public ActionResult Create()
        {
            var project = db.Project.ToList();
            var model = new TaskViewModel
            {
                Projects = db.Project.ToList(),
                Users = db.User.ToList(),
                TaskPriority = db.TaskPriority.ToList(),
                TaskStatus = db.TaskStatus.ToList()
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
                ProjectId = taskVM.Task.ProjectId,
                Project = taskVM.Task.Project,
                UserId = taskVM.Task.UserId,
                AuthorId = GetUserId.GetUserIdentity(User.Identity.Name),
                User = taskVM.Task.User,
                PriorityId = taskVM.Task.PriorityId,
                DateAdded = DateTime.Now,
                DateClosed = taskVM.Task.DateClosed,
                Contents = taskVM.Task.Contents
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
                Projects = db.Project.ToList(),
                Users = db.User.ToList()
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
                Projects = db.Project.ToList(),
                Users = db.User.ToList(),
                TaskPriority = db.TaskPriority.ToList(),
                TaskStatus = db.TaskStatus.ToList()
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
                ProjectId = taskVM.Task.ProjectId,
                Project = taskVM.Task.Project,
                UserId = taskVM.Task.UserId,
                AuthorId = taskVM.Task.AuthorId,
                User = taskVM.Task.User,
                PriorityId = taskVM.Task.PriorityId,
                DateAdded = taskVM.Task.DateAdded,
                DateClosed = taskVM.Task.DateClosed,
                Contents = taskVM.Task.Contents
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
                Projects = db.Project.ToList(),
                Users = db.User.ToList()
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

        // GET: Task/Edit/5
        public ActionResult WorkOnTask(int? id)
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

            if (task.DateClosed != null)
            {
                Session["DateClosed"] = 1;
            }
            else
            {
                Session["DateClosed"] = 0;
            }

            var model = new TaskViewModel
            {
                Task = task,
                Projects = db.Project.ToList(),
                Users = db.User.ToList(),
                TaskPriority = db.TaskPriority.ToList(),
                TaskStatus = db.TaskStatus.ToList()
            };

            ViewBag.TaskName = model.Task.Title;
            ViewBag.TaskId = model.Task.Id;
            return View(model);
        }

        // POST: Task/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult WorkOnTask(TaskViewModel taskVM)
        {
            var task = new Task
            {
                Id = taskVM.Task.Id,
                Title = taskVM.Task.Title,
                StatusId = taskVM.Task.StatusId,
                ProjectId = taskVM.Task.ProjectId,
                Project = taskVM.Task.Project,
                UserId = taskVM.Task.UserId,
                AuthorId = taskVM.Task.AuthorId,
                User = taskVM.Task.User,
                PriorityId = taskVM.Task.PriorityId,
                DateAdded = taskVM.Task.DateAdded,
                DateClosed = taskVM.Task.DateClosed,
                Contents = taskVM.Task.Contents
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
