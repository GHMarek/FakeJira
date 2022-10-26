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
            if (!User.IsInRole("Admin"))
            {
                return View("Index", db.Task.Where(x => x.User.EmailAddress == User.Identity.Name).Include(t => t.Project)
                        .Include(t => t.User)
                        .Include(t => t.TaskStatus)
                        .Include(t => t.TaskPriority)
                        .ToList());
            }

            return View(db.Task.Include(t => t.Project)
                    .Include(t => t.User)
                    .Include(t => t.TaskStatus)
                    .Include(t => t.TaskPriority)
                    .ToList());
        }
        public ActionResult IndexFilterProject(string id)
        {
           
            return View("Index", db.Task.Where(x => x.Project.Name == id).Include(t => t.Project)
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

            taskVM.Task.Project = new Project
            {
                Id = taskVM.Task.ProjectId,
                Name = db.Project.Where(x => x.Id == taskVM.Task.ProjectId).ToString()
            };

            //taskVM.Task.Author = new User
            //{
            //    Id = taskVM.Task.AuthorId,
            //    FirstName = db.User.Where(x => x.Id == taskVM.Task.AuthorId).Select(x => x).FirstOrDefault().FirstName,
            //    LastName = db.User.Where(x => x.Id == taskVM.Task.AuthorId).Select(x => x).FirstOrDefault().LastName,
            //    EmailAddress = db.User.Where(x => x.Id == taskVM.Task.AuthorId).Select(x => x).FirstOrDefault().EmailAddress,
            //    DepartmentId = db.User.Where(x => x.Id == taskVM.Task.AuthorId).Select(x => x).FirstOrDefault().DepartmentId,
            //    Department = new Department
            //    {
            //        Id = db.Department.Where(x => x.Id == db.User.Where(y => y.Id == taskVM.Task.AuthorId).Select(y => y).FirstOrDefault().DepartmentId).FirstOrDefault().Id,
            //        Name = db.Department.Where(x => x.Id == db.User.Where(y => y.Id == taskVM.Task.AuthorId).Select(y => y).FirstOrDefault().DepartmentId).Select(x => x).FirstOrDefault().Name
            //    },
            //    BusinessRoleId = db.User.Where(x => x.Id == taskVM.Task.AuthorId).Select(x => x).ToList()[0].BusinessRoleId,
            //    BusinessRole = new BusinessRole
            //    {
            //        Id = Convert.ToInt32(db.User.Where(x => x.Id == taskVM.Task.AuthorId).Select(x => x).ToList()[0].BusinessRoleId),
            //        Name = db.BusinessRole.Where(y => y.Id == Convert.ToInt32(db.User.Where(x => x.Id == taskVM.Task.AuthorId).Select(x => x).FirstOrDefault().BusinessRoleId)).FirstOrDefault().Name,
            //        Manager = db.BusinessRole.Where(y => y.Id == Convert.ToInt32(db.User.Where(x => x.Id == taskVM.Task.AuthorId).Select(x => x).FirstOrDefault().BusinessRoleId)).FirstOrDefault().Manager,
            //        ParentManagerId = db.BusinessRole.Where(y => y.Id == Convert.ToInt32(db.User.Where(x => x.Id == taskVM.Task.AuthorId).Select(x => x).FirstOrDefault().BusinessRoleId)).FirstOrDefault().ParentManagerId
            //    },
            //    Picture = db.User.Where(x => x.Id == taskVM.Task.AuthorId).Select(x => x).ToList()[0].Picture

            //};



            //taskVM.Task.Author = db.Users.Where(x => x.Id == taskVM.Task.AuthorId.ToString()).Select(x => x).ToList()[0];


            //var task = taskVM.Task;
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
            //TODO: tutaj po prostu z formularza nie przychodzi pełny taskVM, niektóre pola są nullem

            Task task = new Task
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
                Contents = taskVM.Task.Contents,
                TaskPriority = taskVM.Task.TaskPriority,
                TaskStatus = taskVM.Task.TaskStatus,
                Author = taskVM.Task.Author
            };

            if (ModelState.IsValid)
            {
                db.Entry(task).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            taskVM.Projects = db.Project.ToList();
            return View();
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

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult WorkOnTask(TaskViewModel taskVM)
        //{
        //    var task = new Task
        //    {
        //        Id = taskVM.Task.Id,
        //        Title = taskVM.Task.Title,
        //        StatusId = taskVM.Task.StatusId,
        //        ProjectId = taskVM.Task.ProjectId,
        //        Project = taskVM.Task.Project,
        //        UserId = taskVM.Task.UserId,
        //        AuthorId = taskVM.Task.AuthorId,
        //        User = taskVM.Task.User,
        //        PriorityId = taskVM.Task.PriorityId,
        //        DateAdded = taskVM.Task.DateAdded,
        //        DateClosed = taskVM.Task.DateClosed,
        //        Contents = taskVM.Task.Contents
        //    };

        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(task).State = EntityState.Modified;
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    taskVM.Projects = db.Project.ToList();
        //    return View(task);
        //}
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
