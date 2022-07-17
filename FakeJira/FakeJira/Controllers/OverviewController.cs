using FakeJira.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FakeJiraDataLibrary.DataAccess;

namespace FakeJira.Controllers
{
    public class OverviewController : Controller
    {
        private ApplicationDbContext db;
        public OverviewController()
        {
            db = new ApplicationDbContext();
        }
        // GET: Overview
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DataSetup()
        {
            try
            {
                AppDataSetup.DataSetup();
                ViewBag.DataSetup = "Data setup succesfull";
            }
            catch(Exception ex)
            {
                ViewBag.DataSetup = $"Data setup unsuccesfull, error message: {ex.Message}";
            }
            
            return RedirectToAction("Index");
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}