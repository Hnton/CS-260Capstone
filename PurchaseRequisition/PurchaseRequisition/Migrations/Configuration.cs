namespace PurchaseRequisition.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using PurchaseRequisition.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PurchaseRequisition.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PurchaseRequisition.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var UserManager = new UserManager<Employee>(new UserStore<Employee>(context));
            var PasswordHash = new PasswordHasher();

            // ADDING ROLES
            context.Roles.AddOrUpdate(p => p.Id,
                new IdentityRole { Name = "Admin" },
                new IdentityRole { Name = "Supervisor" },
                new IdentityRole { Name = "Purchasing" },
                new IdentityRole { Name = "Auditor" },
                new IdentityRole { Name = "CFO" },
                new IdentityRole { Name = "User" }
                );

            context.Statuses.AddOrUpdate(s => s.ID,
                new Status { StatusName = "Approved", TimeStamp = DateTime.Now },
                new Status { StatusName = "Pending", TimeStamp = DateTime.Now },
                new Status { StatusName = "Denied", TimeStamp = DateTime.Now }
                );

            context.Categories.AddOrUpdate(c => c.ID,
                new Category { CategoryName = "Books and Periodicals", TimeStamp = DateTime.Now },
                new Category { CategoryName = "Computer Supplies", TimeStamp = DateTime.Now },
                new Category { CategoryName = "Computer Software - Less than $5,000", TimeStamp = DateTime.Now },
                new Category { CategoryName = "Student Activities", TimeStamp = DateTime.Now },
                new Category { CategoryName = "Office Expenses", TimeStamp = DateTime.Now }, 
                new Category { CategoryName = "Other General Expenses", TimeStamp = DateTime.Now },
                new Category { CategoryName = "Postage and Freight", TimeStamp = DateTime.Now },
                new Category { CategoryName = "Printing and Binding", TimeStamp = DateTime.Now },
                new Category { CategoryName = "Rent of Machines and Operating Leases", TimeStamp = DateTime.Now },
                new Category { CategoryName = "Research and Educational Supplies", TimeStamp = DateTime.Now },
                new Category { CategoryName = "Training and Development of Employees", TimeStamp = DateTime.Now },
                new Category { CategoryName = "Travel - Within US", TimeStamp = DateTime.Now },
                new Category { CategoryName = "Vehicle Rental - Within US", TimeStamp = DateTime.Now },
                new Category { CategoryName = "Contractual and Professional Services", TimeStamp = DateTime.Now }

                );
                

            //ADDING ADDRESSES
            context.Addresses.AddOrUpdate(a => a.ID,
                new Address
                {
                    ID = 1,
                    City = "Parkersburg",
                    State = "West Virginia",
                    StreetAddress = "300 Campus Dr.",
                    ZIP = "26101",
                    TimeStamp = DateTime.Now
                },
                new Address
                {
                    ID = 2,
                    City = "Ripley",
                    State = "West Virginia",
                    StreetAddress = "105 Academy Dr.",
                    ZIP = "25271",
                    TimeStamp = DateTime.Now
                });

            //ADDING CAMPUSES
            context.Campuses.AddOrUpdate(c => c.ID,
                new Campus
                {
                    ID = 1,
                    CampusName = "West Virginia University at Parkersburg",
                    AddressID = 1,
                    Active = true,
                    TimeStamp = DateTime.Now,

                },
                new Campus
                {
                    ID = 2,
                    CampusName = "WVUP Jackson County Center",
                    AddressID = 2,
                    Active = true,
                    TimeStamp = DateTime.Now,
                });

            //ADDING ROOMS
            context.Rooms.AddOrUpdate(r => r.ID,
                new Room
                {
                    ID = 1,
                    RoomCode = "C219C",
                    RoomName = "C219C",
                    Active = true,
                    CampusID = 1,
                    TimeStamp = DateTime.Now,
                },
                new Room
                {
                    ID = 2,
                    RoomCode = "0103",
                    RoomName = "IT Office",
                    Active = true,
                    CampusID = 1,
                    TimeStamp = DateTime.Now,
                },
                new Room
                {
                    ID = 3,
                    RoomCode = "1116",
                    RoomName = "Business Office",
                    Active = true,
                    CampusID = 1,
                    TimeStamp = DateTime.Now,
                },
                new Room
                {
                    ID = 4,
                    RoomCode = "102C",
                    RoomName = "Director of Maintenance Office",
                    Active = true,
                    CampusID = 1,
                    TimeStamp = DateTime.Now,
                },
                new Room
                {
                    ID = 5,
                    RoomCode = "1112B",
                    RoomName = "Administration Office",
                    Active = true,
                    CampusID = 1,
                    TimeStamp = DateTime.Now,
                },
                new Room
                {
                    ID = 6,
                    RoomCode = "0104B",
                    RoomName = "Maintenance Office",
                    Active = true,
                    CampusID = 1,
                    TimeStamp = DateTime.Now,
                },
                new Room
                {
                    ID = 7,
                    RoomCode = "1105",
                    RoomName = "President's Office",
                    Active = true,
                    CampusID = 1,
                    TimeStamp = DateTime.Now,
                },
                new Room
                {
                    ID = 8,
                    RoomCode = "0128D",
                    RoomName = "STEM Office",
                    Active = true,
                    CampusID = 1,
                    TimeStamp = DateTime.Now,
                },
                new Room
                {
                    ID = 9,
                    RoomCode = "1004",
                    RoomName = "CFO Office",
                    Active = true,
                    CampusID = 1,
                    TimeStamp = DateTime.Now,
                },
                new Room
                {
                    ID = 10,
                    RoomCode = "1026B",
                    RoomName = "Fine Arts Office",
                    Active = true,
                    CampusID = 1,
                    TimeStamp = DateTime.Now,
                },
                 new Room
                 {
                     ID = 11,
                     RoomCode = "C103C",
                     RoomName = "C103C",
                     Active = true,
                     CampusID = 1,
                     TimeStamp = DateTime.Now,
                 });

            // ADDING CHAD CRUMBAKER
            if (!context.Users.Any(u => u.UserName == "chad.crumbaker@develop.com"))
            {
                var supervisor3 = new Employee
                {
                    Id = "CHAD",
                    UserName = "chad.crumbaker@develop.com",
                    Email = "chad.crumbaker@develop.com",
                    PhoneNumber = "(304) 424-8000 x244",
                    FirstName = "Chad",
                    LastName = "Crumbaker",
                    Active = true,
                    RoomID = 5,

                    PasswordHash = PasswordHash.HashPassword("Admin1234!")
                };

                UserManager.Create(supervisor3);
                UserManager.AddToRole(supervisor3.Id, "Supervisor");
            }


            // ADDING CHRIS GILMER
            if (!context.Users.Any(u => u.UserName == "president@develop.com"))
            {
                var supervisor4 = new Employee
                {
                    Id = "CHRIS",
                    UserName = "president@develop.com",
                    Email = "president@develop.com",
                    PhoneNumber = "(304) 424-8000 x232",
                    FirstName = "Chris",
                    LastName = "Gilmer",
                    Active = true,
                    RoomID = 7,

                    PasswordHash = PasswordHash.HashPassword("Admin1234!")
                };

                UserManager.Create(supervisor4);
                UserManager.AddToRole(supervisor4.Id, "Supervisor");
            }


            // ADDING DAVE GATES
            if (!context.Users.Any(u => u.UserName == "david.gates@develop.com"))
            {
                var user2 = new Employee
                {
                    Id = "DAVE",
                    UserName = "david.gates@develop.com",
                    Email = "david.gates@develop.com",
                    PhoneNumber = "(304) 424-8000 x382",
                    FirstName = "David",
                    LastName = "gates",
                    Active = true,
                    RoomID = 6,

                    PasswordHash = PasswordHash.HashPassword("Admin1234!")
                };

                UserManager.Create(user2);
                UserManager.AddToRole(user2.Id, "User");
            }


            // ADDING JARED GUMP
            if (!context.Users.Any(u => u.UserName == "jared.gump@develop.com"))
            {
                var supervisor5 = new Employee
                {
                    Id = "JARED",
                    UserName = "jared.gump@develop.com",
                    Email = "jared.gump@develop.com",
                    PhoneNumber = "(304) 424-8000 x226",
                    FirstName = "Jared",
                    LastName = "Gump",
                    Active = true,
                    RoomID = 8,

                    PasswordHash = PasswordHash.HashPassword("Admin1234!")
                };

                UserManager.Create(supervisor5);
                UserManager.AddToRole(supervisor5.Id, "Supervisor");
            }


            // ADDING ALICE HARRIS
            if (!context.Users.Any(u => u.UserName == "alice.harris@develop.com"))
            {
                var CFO1 = new Employee
                {
                    Id = "ALICE",
                    UserName = "alice.harris@develop.com",
                    Email = "alice.harris@develop.com",
                    PhoneNumber = "(304) 424-8000 x224",
                    FirstName = "Alice",
                    LastName = "Harris",
                    Active = true,
                    RoomID = 9,

                    PasswordHash = PasswordHash.HashPassword("Admin1234!")
                };

                UserManager.Create(CFO1);
                UserManager.AddToRole(CFO1.Id, "CFO");
            }

            //ADDING DIVISIONS
            context.Divisions.AddOrUpdate(d => d.ID,
               new Division
               {
                   ID = 1,
                   DivisionName = "Science, Technology, Engineering & Math",
                   Active = true,
                   TimeStamp = DateTime.Now,
                   SupervisorID = "JARED"
               },
               new Division
               {
                   ID = 2,
                   DivisionName = "Information Technology",
                   Active = true,
                   TimeStamp = DateTime.Now,
                   SupervisorID = "ALICE"
               },
               new Division
               {
                   ID = 3,
                   DivisionName = "Business",
                   Active = true,
                   TimeStamp = DateTime.Now,
                   SupervisorID = "ALICE"
               },
               new Division
               {
                   ID = 4,
                   DivisionName = "Maintenance",
                   Active = true,
                   TimeStamp = DateTime.Now,
                   SupervisorID = "DAVE"
               },
               new Division
               {
                   ID = 5,
                   DivisionName = "Academic and Student Affairs",
                   Active = true,
                   TimeStamp = DateTime.Now,
                   SupervisorID = "CHRIS"
               },
                new Division
                {
                    ID = 6,
                    DivisionName = "Office of the President",
                    Active = true,
                    TimeStamp = DateTime.Now,
                    SupervisorID = "ALICE"
                }, new Division
                {
                    ID = 7,
                    DivisionName = "Humanities and Fine Arts",
                    Active = true,
                    TimeStamp = DateTime.Now,
                    SupervisorID = "CHAD"
                }
                );

            //ADDING DEPARTMENTS
            context.Departments.AddOrUpdate(d => d.ID,
                new Department
                {
                    ID = 1,
                    DepartmentName = "Computer Science",
                    DivisionID = 1,
                    Active = true,
                    TimeStamp = DateTime.Now
                },
                new Department
                {
                    ID = 2,
                    DepartmentName = "Information Technology",
                    DivisionID = 2,
                    Active = true,
                    TimeStamp = DateTime.Now
                },
                new Department
                {
                    ID = 3,
                    DepartmentName = "Business",
                    DivisionID = 3,
                    Active = true,
                    TimeStamp = DateTime.Now
                },
                new Department
                {
                    ID = 4,
                    DepartmentName = "Maintenance",
                    DivisionID = 4,
                    Active = true,
                    TimeStamp = DateTime.Now
                },
                new Department
                {
                    ID = 5,
                    DepartmentName = "Office of Academic Affairs",
                    DivisionID = 5,
                    Active = true,
                    TimeStamp = DateTime.Now
                },
                new Department
                {
                    ID = 6,
                    DepartmentName = "Office of the President",
                    DivisionID = 6,
                    Active = true,
                    TimeStamp = DateTime.Now
                },
                new Department
                {
                    ID = 7,
                    DepartmentName = "STEM",
                    DivisionID = 1,
                    Active = true,
                    TimeStamp = DateTime.Now
                },
                 new Department
                 {
                     ID = 8,
                     DepartmentName = "Humanities and Fine Arts",
                     DivisionID = 7,
                     Active = true,
                     TimeStamp = DateTime.Now
                 }
                );
 

            //ADDING ADMIN
            if (!context.Users.Any(u => u.UserName == "Admin@develop.com"))
            {
                var admin = new Employee
                {
                    UserName = "Admin@develop.com",
                    Email = "Admin@Develop.com",
                    FirstName = "Admin",
                    LastName = "Admin",
                    Active = true,
                    PasswordHash = PasswordHash.HashPassword("Admin1234!")
                };

                UserManager.Create(admin);
                UserManager.AddToRole(admin.Id, "Admin");
            }
            // ADDING AUDITOR
            if (!context.Users.Any(u => u.UserName == "Auditor@develop.com"))
            {
                var auditor = new Employee
                {
                    UserName = "Auditor@develop.com",
                    Email = "Auditor@develop.com",
                    FirstName = "Auditor",
                    LastName = "Auditor",
                    Active = true,
                    PasswordHash = PasswordHash.HashPassword("Admin1234!")
                };

                UserManager.Create(auditor);
                UserManager.AddToRole(auditor.Id, "Auditor");
            }

            // ADDING CHARLES ALMOND
            if (!context.Users.Any(u => u.UserName == "Charles.Almond@develop.com"))
            {
                var user1 = new Employee
                {
                    UserName = "Charles.Almond@develop.com",
                    Email = "Charles.Almond@Develop.com",
                    PhoneNumber = "(304) 424-8000 x239",
                    FirstName = "Charles",
                    LastName = "Almond",
                    Active = true,
                    RoomID = 1,
                    DepartmentID = 1,
                    
                    PasswordHash = PasswordHash.HashPassword("Admin1234!")
                };

                UserManager.Create(user1);
                UserManager.AddToRole(user1.Id, "User");
            }

            // ADDING DOUG ANTHONY
            if (!context.Users.Any(u => u.UserName == "doug.anthony@develop.com"))
            {
                var supervisor1 = new Employee
                {
                    UserName = "doug.anthony@develop.com",
                    Email = "doug.anthony@develop.com",
                    PhoneNumber = "(304) 424-8000 x280",
                    FirstName = "Doug",
                    LastName = "Anthony",
                    Active = true,
                    RoomID = 2,
                    DepartmentID = 2,

                    PasswordHash = PasswordHash.HashPassword("Admin1234!")
                };

                UserManager.Create(supervisor1);
                UserManager.AddToRole(supervisor1.Id, "Supervisor");
            }

            // ADDING MICHAEL CAPLINGER
            if (!context.Users.Any(u => u.UserName == "michael.caplinger@develop.com"))
            {
                var purchasing1 = new Employee
                {
                    UserName = "michael.caplinger@develop.com",
                    Email = "michael.caplinger@develop.com",
                    PhoneNumber = "(304) 424-8000 x999",
                    FirstName = "Michael",
                    LastName = "Caplinger",
                    Active = true,
                    RoomID = 3,
                    DepartmentID = 3,

                    PasswordHash = PasswordHash.HashPassword("Admin1234!")
                };

                UserManager.Create(purchasing1);
                UserManager.AddToRole(purchasing1.Id, "Purchasing");
            }

            // ADDING BOB COOPER
            if (!context.Users.Any(u => u.UserName == "bob.cooper@develop.com"))
            {
                var supervisor2 = new Employee
                {
                    UserName = "bob.cooper@develop.com",
                    Email = "bob.cooper@develop.com",
                    PhoneNumber = "(304) 424-8000 x265",
                    FirstName = "Bob",
                    LastName = "Cooper",
                    Active = true,
                    RoomID = 4,
                    DepartmentID = 4,

                    PasswordHash = PasswordHash.HashPassword("Admin1234!")
                };

                UserManager.Create(supervisor2);
                UserManager.AddToRole(supervisor2.Id, "Supervisor");
            }





            // ADDING TORIE JACKSON
            if (!context.Users.Any(u => u.UserName == "torie.jackson@develop.com"))
            {
                var supervisor6 = new Employee
                {
                    UserName = "torie.jackson@develop.com",
                    Email = "torie.jackson@develop.com",
                    PhoneNumber = "(304) 424-8000 x247",
                    FirstName = "Torie",
                    LastName = "Jackson",
                    Active = true,
                    RoomID = 10,
                    DepartmentID = 8,
                    

                    PasswordHash = PasswordHash.HashPassword("Admin1234!")
                };

                UserManager.Create(supervisor6);
                UserManager.AddToRole(supervisor6.Id, "Supervisor");
            }

            // ADDING BILL MINEAR
            if (!context.Users.Any(u => u.UserName == "bill.minear@develop.com"))
            {
                var user3 = new Employee
                {
                    UserName = "bill.minear@develop.com",
                    Email = "bill.minear@develop.com",
                    PhoneNumber = "(304) 424-8000 x247",
                    FirstName = "Bill",
                    LastName = "Minear",
                    Active = true,
                    RoomID = 2,
                    DepartmentID = 2,

                    PasswordHash = PasswordHash.HashPassword("Admin1234!")
                };

                UserManager.Create(user3);
                UserManager.AddToRole(user3.Id, "User");
            }

            // ADDING JEREMY STARKEY
            if (!context.Users.Any(u => u.UserName == "jeremy.starkey@develop.com"))
            {
                var supervisor7 = new Employee
                {
                    UserName = "jeremy.starkey@develop.com",
                    Email = "jeremy.starkey@develop.com",
                    PhoneNumber = "(304) 424-8000 x379",
                    FirstName = "Jeremy",
                    LastName = "Starkey",
                    Active = true,
                    RoomID = 5,
                    DepartmentID = 5,

                    PasswordHash = PasswordHash.HashPassword("Admin1234!")
                };

                UserManager.Create(supervisor7);
                UserManager.AddToRole(supervisor7.Id, "Supervisor");
            }

            // ADDING Gary Thompson
            if (!context.Users.Any(u => u.UserName == "gary.thompson@develop.com"))
            {
                var supervisor2 = new Employee
                {
                    UserName = "gary.thompson@develop.com",
                    Email = "gary.thompson@develop.com",
                    PhoneNumber = "(304) 424-8000 x419",
                    FirstName = "Gary",
                    LastName = "Thompson",
                    Active = true,
                    RoomID = 11,
                    DepartmentID = 1,

                    PasswordHash = PasswordHash.HashPassword("Admin1234!")
                };

                UserManager.Create(supervisor2);
                UserManager.AddToRole(supervisor2.Id, "User");
            }



        }
    }
}
