using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FakeJiraDataLibrary.DataAccess
{
    public class AppDataSetup
    {
        //This class is made for application data setup purpose only.
        //It means all the data app need for fresh start ie. TaskStatus, TaskPriority, Projects etc.
        //Methods grouped below are supposed to work only once, if really needed.
        public static void DataSetup()
        {
            AddBasicTaskStatus();
            AddBasicTaskPriorities();
            AddBasicProjects();
            AddBasicDepartments();
        }
        public static void AddBasicTaskStatus()
        {
            var TaskStatusCount = SQLDataAccess.LoadData<int>("select count(*) from dbo.TaskStatus").ToList().FirstOrDefault();
            if (Convert.ToInt32(TaskStatusCount) == 0)
            {
                Dictionary<int, string> newStatusDict = new Dictionary<int, string>() { };

                newStatusDict.Add(1, "New");
                newStatusDict.Add(2, "Unresolved");
                newStatusDict.Add(3, "Rejected");
                newStatusDict.Add(4, "Resolved");

                List<Models.TaskStatus> newStatusList = new List<Models.TaskStatus>() { };

                foreach (var item in newStatusDict)
                {
                    newStatusList.Add(new Models.TaskStatus { Id = item.Key, Name = item.Value });
                }

                string sql = "insert into dbo.TaskStatus (Name) values (@Name);";

                SQLDataAccess.SaveData(sql, newStatusList);


            }
        }
        public static void AddBasicTaskPriorities()
        {
            var TaskPriorityCount = SQLDataAccess.LoadData<int>("select count(*) from dbo.TaskPriorities").ToList().FirstOrDefault();
            if (Convert.ToInt32(TaskPriorityCount) == 0)
            {
                Dictionary<int, string> newPriorityDict = new Dictionary<int, string>() { };

                newPriorityDict.Add(1, "Low");
                newPriorityDict.Add(2, "Normal");
                newPriorityDict.Add(3, "Urgent");
                newPriorityDict.Add(4, "Immediate");

                List<Models.TaskStatus> newStatusList = new List<Models.TaskStatus>() { };

                foreach (var item in newPriorityDict)
                {
                    newStatusList.Add(new Models.TaskStatus { Id = item.Key, Name = item.Value });
                }

                string sql = "insert into dbo.TaskPriorities (Name) values (@Name);";

                SQLDataAccess.SaveData(sql, newStatusList);
            }
        }
        public static void AddBasicProjects()
        {
            var ProjectPriorityCount = SQLDataAccess.LoadData<int>("select count(*) from dbo.Projects").ToList().FirstOrDefault();
            if (Convert.ToInt32(ProjectPriorityCount) == 0)
            {
                Dictionary<int, string> newProjectsDict = new Dictionary<int, string>() { };

                newProjectsDict.Add(1, "Administration");
                newProjectsDict.Add(2, "Important stuff");
                newProjectsDict.Add(3, "Finance");
                newProjectsDict.Add(4, "Analytics");

                List<Models.Project> newProjectList = new List<Models.Project>() { };

                foreach (var item in newProjectsDict)
                {
                    newProjectList.Add(new Models.Project { Id = item.Key, Name = item.Value });
                }

                string sql = "insert into dbo.Projects (Name) values (@Name);";

                SQLDataAccess.SaveData(sql, newProjectList);
            }
        }
        public static void AddBasicDepartments()
        {
            var DepartmentCount = SQLDataAccess.LoadData<int>("select count(*) from dbo.Departments").ToList().FirstOrDefault();
            if (Convert.ToInt32(DepartmentCount) == 0)
            {
                Dictionary<int, string> newDepartmentsDict = new Dictionary<int, string>() { };

                newDepartmentsDict.Add(1, "CEO");
                newDepartmentsDict.Add(2, "Customer Service");
                newDepartmentsDict.Add(3, "It");
                newDepartmentsDict.Add(4, "Accounting");

                List<Models.Department> newDepartmentList = new List<Models.Department>() { };

                foreach (var item in newDepartmentsDict)
                {
                    newDepartmentList.Add(new Models.Department { Id = item.Key, Name = item.Value });
                }

                string sql = "insert into dbo.Departments (Name) values (@Name);";

                SQLDataAccess.SaveData(sql, newDepartmentList);
            }
        }


    }
}
