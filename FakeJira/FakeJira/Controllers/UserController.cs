﻿using FakeJira.Models;
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

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

    }
}