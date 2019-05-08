using System;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Identity;
using Microsoft.Owin.Security;
using PurchaseRequisition.Models;
using PurchaseRequisition.Models.ViewModels;
using static PurchaseRequisition.Models.ViewModels.AdminViewModels;

namespace PurchaseRequisition.Controllers
{

    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {

        ApplicationDbContext context = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        //// Display Employee with Department,Room, and Role
        //public ActionResult EmployeeWithDepartmentRoomRole()
        //{

        //    var list = (from e in context.Employees
        //                from roles in e.Roles
        //                join d in context.Departments on e.DepartmentID equals d.ID
        //                join m in context.Rooms on e.RoomID equals m.ID
        //                join r in context.Roles on roles.RoleId equals r.Id
        //                into ThisList
        //                from r in ThisList.DefaultIfEmpty()
        //                select new
        //                {
        //                    EmployeeName = e.FirstName + " " + e.LastName,
        //                    Email = e.Email,
        //                    Active = e.Active,
        //                    DepartmentName = d.DepartmentName,
        //                    RoomName = m.RoomName,
        //                    RoomCode = m.RoomCode,
        //                    RoleName = r.Name
        //                }).ToList()
        //                .Select(x => new EmployeeWithDepartmentRoomRoleViewModels()
        //                {
        //                    EmployeeName = x.EmployeeName,
        //                    Email = x.Email,
        //                    Active = x.Active,
        //                    DepartmentName = x.DepartmentName,
        //                    RoomName = x.RoomName,
        //                    RoomCode = x.RoomCode,
        //                    RoleName = x.RoleName
        //                });


        //    return View(list);

        //}

        public ActionResult ListUsers()
        {
            var query = context.Employees.ToList();

            return View(query);
        }

        public ActionResult DeleteUsers(string id)
        {
            var user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            return View(user);
        }

        [HttpPost]
        public ActionResult DeleteUsers(Employee appuser)
        {
            var user = context.Users.Where(u => u.Id == appuser.Id).FirstOrDefault();
            context.Users.Remove(user);
            context.SaveChanges();
            //var user = context.Users.Where(u => u.Id == id.ToString()).FirstOrDefault();
            return RedirectToAction("ListUsers");
        }

        public ActionResult EditUsers(string id)
        {
            var context = new Models.ApplicationDbContext();
            var user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            ViewBag.DepartmentID = new SelectList(context.Departments, "ID", "DepartmentName");
            ViewBag.RoomID = new SelectList(context.Rooms, "ID", "RoomName");
            ViewBag.Name = new SelectList(context.Roles.Where(u => !u.Name.Contains("Admin")).ToList(), "Name", "Name");
            return View(user);
        }

        [HttpPost]
        public ActionResult EditUsers(Employee appuser)
        {
            var user = context.Employees.Where(u => u.Id == appuser.Id).FirstOrDefault();
            ViewBag.DepartmentID = new SelectList(context.Departments, "ID", "DepartmentName", appuser.DepartmentID);
            ViewBag.DivisionID = new SelectList(context.Rooms, "ID", "RoomName", appuser.RoomID);
            ViewBag.Name = new SelectList(context.Roles.Where(u => !u.Name.Contains("Admin"))
                                          .ToList(), "Name", "Name");
            //context.Entry(appuser).State = EntityState.Modified;
            user.Email = appuser.Email;
            user.FirstName = appuser.FirstName;
            user.LastName = appuser.LastName;
            user.Active = appuser.Active;
            user.DepartmentID = appuser.DepartmentID;
            user.RoomID = appuser.RoomID;
            context.SaveChanges();
            //var user = context.Users.Where(u => u.Id == id.ToString()).FirstOrDefault();
            return RedirectToAction("ListUsers");
        }

        // GET: Roles
        public ActionResult ListRoles()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }
    }


}