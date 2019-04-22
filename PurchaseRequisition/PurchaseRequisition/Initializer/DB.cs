using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PurchaseRequisition.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace PurchaseRequisition.Initializer
{
    public class DB : DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            //var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            //var UserManager = new UserManager<Employee>(new UserStore<Employee>(context));

            //context.Roles.AddOrUpdate(p => p.Id,
            //    new IdentityRole { Name = "Admin" },
            //    new IdentityRole { Name = "Supervisor" },
            //    new IdentityRole { Name = "Purchasing" },
            //    new IdentityRole { Name = "Auditor" },
            //    new IdentityRole { Name = "CFO" },
            //    new IdentityRole { Name = "User" }
            //    );
            

            //// creating Creating Supervisor role    
            //if (!roleManager.RoleExists("Supervisor"))
            //{
            //    var role = new IdentityRole
            //    {
            //        Name = "Supervisor"
            //    };
            //    context.Roles.Add(role);
            //}

            //// Creating Purchasing role    
            //if (!roleManager.RoleExists("Purchasing"))
            //{
            //    var role = new IdentityRole
            //    {
            //        Name = "Purchasing"
            //    };
            //    roleManager.Create(role);

            //}

            //// Creating Auditor role    
            //if (!roleManager.RoleExists("Auditor"))
            //{
            //    var role = new IdentityRole
            //    {
            //        Name = "Auditor"
            //    };
            //    roleManager.Create(role);

            //}

            //// Creating CFO role    
            //if (!roleManager.RoleExists("CFO"))
            //{
            //    var role = new IdentityRole
            //    {
            //        Name = "CFO"
            //    };
            //    roleManager.Create(role);

            //}

            //// Creating User role    
            //if (!roleManager.RoleExists("User"))
            //{
            //    var role = new IdentityRole
            //    {
            //        Name = "User"
            //    };
            //    roleManager.Create(role);
            //}



            ////In Startup iam creating first Admin Role and creating a default Admin User
            //if (!roleManager.RoleExists("Admin"))
            //{

            //    //first we create Admin rool
            //    var role = new IdentityRole
            //    {
            //        Name = "Admin"
            //    };
            //    roleManager.Create(role);

            //    //Here we create a Admin super user who will maintain the website

            //    var user = new Employee
            //    {
            //        UserName = "Admin@Develop.com",
            //        Email = "Admin@Develop.com",
            //        FirstName = "ADMIN",
            //        LastName = "ADMIN",
            //        Active = true
            //    };

            //    string userPWD = "Admin1234!";

            //    var chkUser = UserManager.Create(user, userPWD);

            //    //Add default User to Role Admin
            //    if (chkUser.Succeeded)
            //    {
            //        var result1 = UserManager.AddToRole(user.Id, "Admin");

            //    }
            //}
            //base.Seed(context);
        }
    }
}