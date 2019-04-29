using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PurchaseRequisition.Models;
using PurchaseRequisition.Models.ViewModels;

namespace PurchaseRequisition.Controllers
{
    public class DivisionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Divisions
        public ActionResult Index()
        {
            //var divisions = db.Divisions.Include(d => d.Supervisor);
            //return View(divisions.ToList());

            var list = (from d in db.Divisions
                        join e in db.Employees
                        on d.SupervisorID equals e.Id into ThisList
                        from e in ThisList.DefaultIfEmpty()
                        select new
                        {
                            DivisionName = d.DivisionName,
                            Active = d.Active,
                            SupervisorName = e.FirstName + " " + e.LastName,


                        }).ToList()
                        .Select(x => new DivisionWithSupervisorViewModels()
                        {
                            DivisionName = x.DivisionName,
                            Active = x.Active,
                            SupervisorName = x.SupervisorName
                        });

            return View(list);
        }

        // GET: Divisions/Create
        public ActionResult CreateDivisionWithSupervisor()
        {
            var roleManager = new Microsoft.AspNet.Identity.RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            string Supervisor = roleManager.FindByName("Supervisor").Id;
            ViewBag.SupervisorID = new SelectList(db.Users.Where(u => u.Roles.Any(r => r.RoleId == Supervisor)).ToList(), "ID", "Email");
            return View();
        }

        // POST: Divisions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDivisionWithSupervisor(Division division)
        {
            if (ModelState.IsValid)
            {
                db.Divisions.Add(division);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var roleManager = new Microsoft.AspNet.Identity.RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            string Supervisor = roleManager.FindByName("Supervisor").Id;
            ViewBag.SupervisorID = new SelectList(db.Users.Where(u => u.Roles.Any(r => r.RoleId == Supervisor)).ToList(), "ID", "Email");
            return View(division);
        }

        // GET: Divisions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division division = db.Divisions.Find(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            return View(division);
        }

        // GET: Divisions/Create
        public ActionResult Create()
        {
            ViewBag.SupervisorID = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: Divisions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DivisionName,Active,SupervisorID,TimeStamp")] Division division)
        {
            if (ModelState.IsValid)
            {
                db.Divisions.Add(division);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SupervisorID = new SelectList(db.Users, "Id", "Email", division.SupervisorID);
            return View(division);
        }

        // GET: Divisions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division division = db.Divisions.Find(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            ViewBag.SupervisorID = new SelectList(db.Users, "Id", "Email", division.SupervisorID);
            return View(division);
        }

        // POST: Divisions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DivisionName,Active,SupervisorID,TimeStamp")] Division division)
        {
            if (ModelState.IsValid)
            {
                db.Entry(division).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SupervisorID = new SelectList(db.Users, "Id", "Email", division.SupervisorID);
            return View(division);
        }

        // GET: Divisions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Division division = db.Divisions.Find(id);
            if (division == null)
            {
                return HttpNotFound();
            }
            return View(division);
        }

        // POST: Divisions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Division division = db.Divisions.Find(id);
            db.Divisions.Remove(division);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
