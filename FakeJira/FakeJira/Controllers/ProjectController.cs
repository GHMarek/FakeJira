using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FakeJira.Controllers
{
    public class ProjectController : Controller
    {
        //TODO: controller do projektów, pilny
        // GET: Project
        public ActionResult Index()
        {
            return View();
        }
    }
}