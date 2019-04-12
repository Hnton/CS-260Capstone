using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PurchaseRequisition.Models;
using System;
using System.Web.Mvc;

namespace PurchaseRequisition.Controllers
{
    public class HomeController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;

                ViewBag.displayMenu = "No";

                if (isAdminUser())
                {
                    ViewBag.displayMenu = "Admin";
                    return RedirectToAction("Index", "Admin");
                }

                else if(isAuditorUser())
                {
                    ViewBag.displayMenu = "Auditor";                
                    return RedirectToAction("Index", "Auditor");
                }

                else if (isUser())
                {
                    ViewBag.displayMenu = "User";
                    return RedirectToAction("Index", "User");
                }

                else if (isCFOUser())
                {
                    ViewBag.displayMenu = "CFO";
                    return RedirectToAction("Index", "CFO");
                }

                else if (isPurchasingUser())
                {
                    ViewBag.displayMenu = "Purchasing";
                    return RedirectToAction("Index", "Purchasing");
                }

                else if (isSupervisorUser())
                {
                    ViewBag.displayMenu = "Supervisor";
                    return RedirectToAction("Index", "Supervisor");
                }

            }
            else
            {
                ViewBag.Name = "Please Sign in";
            }
            return View();

        }

        // Function to see if user is admin
        public Boolean isAdminUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<Employee>(new UserStore<Employee>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Admin")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        // Function to see if user is only user
        public Boolean isUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<Employee>(new UserStore<Employee>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "User")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        // Function to see if user is CFO
        public Boolean isCFOUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<Employee>(new UserStore<Employee>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "CFO")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        // Function to see if user is Auditor
        public Boolean isAuditorUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<Employee>(new UserStore<Employee>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Auditor")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        // Function to see if user is Purchasing
        public Boolean isPurchasingUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<Employee>(new UserStore<Employee>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Purchasing")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        // Function to see if user is Supervisor
        public Boolean isSupervisorUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<Employee>(new UserStore<Employee>(context));
                var s = UserManager.GetRoles(user.GetUserId());
                if (s[0].ToString() == "Supervisor")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}