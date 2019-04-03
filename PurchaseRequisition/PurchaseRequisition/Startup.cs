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
            createRolesandUsers();

        }
        // In this method we will create default User roles and Admin user for login   
        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<Employee>(new UserStore<Employee>(context));
            
            // Creating Admin role    
            if (!roleManager.RoleExists("Admin"))
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }

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

            //Here we create a Admin super user who will maintain the website                  

            var admin = new Employee
            {

                UserName = "Admin",
                Email = "Admin@Develop.com",
                FirstName = "Admin",
                LastName = "Nimda"
            };

            string userPWD = "Admin1234!";

            var chkUser = UserManager.Create(admin, userPWD);

            //Add default User to Role Admin   
            if (chkUser.Succeeded)
            {
                var result1 = UserManager.AddToRole(admin.Id, "Admin");
            }

            var division = new Division
            {
                DivisionName = "Admin",
                Supervisor = admin,
                Active = true

            };

            var department = new Department
            {
                DepartmentName = "Admin",
                Division = division,
                Active = true
            };

            var address = new Address
            {
                City = "Parkersburg",
                State = "West Virginia",
                StreetAddress = "300 Campus Drive",
                ZIP = "45742",
            };

            var campus = new Campus
            {
                CampusName = "West Virginia University at Parkersburg",
                Address = address,
                Active = true
            };

            var room = new Room
            {
                RoomCode = "0103",
                RoomName = "IT",
                Active = true,
                Campus = campus
            };      
            
        }
    }
}