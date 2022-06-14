using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using System;
using System.Data.SqlClient;
using FakeJiraDataLibrary.DataAccess;
using FakeJiraDataLibrary.Models;
using System.Data;

[assembly: OwinStartupAttribute(typeof(FakeJira.Startup))]
namespace FakeJira
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        //public void AddBasicRoles(RoleManager<IdentityRole> roleManager)
        //{
        //    bool userExists = roleManager.RoleExists("User");

        //    //IDbConnection cnn = new SqlConnection(SQLDataAccess.GetConnectionString());
        //    RoleModel roleModel = new RoleModel();
        //    SQLDataAccess.LoadData<RoleModel>("select top 1 1 from dbo.AspNetRoles");

        //    if(roleModel is null)
        //    {
        //        roleManager.CreateBusinesRole(new IdentityRole("User"));
        //    }

        //}

    }
}
