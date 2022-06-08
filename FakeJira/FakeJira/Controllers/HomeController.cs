using FakeJiraDataLibrary.DataAccess;
using FakeJiraDataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FakeJira.Controllers
{
    [Authorize(Roles = "User, Admin")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Testing()
        {
            ViewBag.Message = "Testing stuff";
            List<EmployeeModel> EmployeesList = new List<EmployeeModel>();
            EmployeesList = SQLDataAccess.LoadData<EmployeeModel>(@"SELECT * FROM [FakeJiraDB].[dbo].[Employee]");
            return View(EmployeesList);
        }
    }
}