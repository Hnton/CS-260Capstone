using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using PurchaseRequisition.Models;

namespace PurchaseRequisition
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesandUsers();

        }
        // In this method we will create default User roles and Admin user for login   
        private void CreateRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<Employee>(new UserStore<Employee>(context));

            // creating Creating Supervisor role    
            if (!roleManager.RoleExists("Supervisor"))
            {
                var role = new IdentityRole();
                role.Name = "Supervisor";
                roleManager.Create(role);

            }

            // Creating Purchasing role    
            if (!roleManager.RoleExists("Purchasing"))
            {
                var role = new IdentityRole();
                role.Name = "Purchasing";
                roleManager.Create(role);

            }

            // Creating Auditor role    
            if (!roleManager.RoleExists("Auditor"))
            {
                var role = new IdentityRole();
                role.Name = "Auditor";
                roleManager.Create(role);

            }

            // Creating CFO role    
            if (!roleManager.RoleExists("CFO"))
            {
                var role = new IdentityRole();
                role.Name = "CFO";
                roleManager.Create(role);

            }

            // Creating User role    
            if (!roleManager.RoleExists("User"))
            {
                var role = new IdentityRole();
                role.Name = "User";
                roleManager.Create(role);
            }



            //In Startup iam creating first Admin Role and creating a default Admin User
            if (!roleManager.RoleExists("Admin"))
            {

                //first we create Admin rool
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website

                var user = new Employee();
                user.UserName = "ADMIN";
                user.Email = "Admin@Develop.com";
                user.FirstName = "ADMIN";
                user.LastName = "ADMIN";
                user.Active = true;

                string userPWD = "Admin1234!";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admin");

                }
            }
        }
    }
}