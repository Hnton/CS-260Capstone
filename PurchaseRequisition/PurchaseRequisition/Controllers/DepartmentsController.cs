using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PurchaseRequisition.Models;
using PurchaseRequisition.Models.ViewModels;

namespace PurchaseRequisition.Controllers
{
    public class DepartmentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Departments
        public ActionResult Index()
        {
            //var departments = db.Departments.Include(d => d.Division);
            //return View(departments.ToList());

            var list = (from d in db.Departments
                        join div in db.Divisions
                        on d.ID equals div.ID into ThisList
                        from div in ThisList.DefaultIfEmpty()
                        select new
                        {
                            DepartmentName = d.DepartmentName,
                            Active = d.Active,
                            DivisionName = div.DivisionName


                        }).ToList()
                        .Select(x => new DepartmentWithDivisionViewModels()
                        {
                            DepartmentName = x.DepartmentName,
                            Active = x.Active,
                            DivisionName = x.DivisionName
                        });

            return View(list);
        }

        //// Display BudgetCodes with Amount
        //public ActionResult DepartmentsWithDivision()
        //{
        //    var list = (from d in db.Departments
        //                join div in db.Divisions
        //                on d.ID equals div.ID into ThisList
        //                from div in ThisList.DefaultIfEmpty()
        //                select new
        //                {
        //                    DepartmentName = d.DepartmentName,
        //                    Active = d.Active,
        //                    DivisionName = div.DivisionName


        //                }).ToList()
        //                .Select(x => new DepartmentWithDivisionViewModels()
        //                {
        //                    DepartmentName = x.DepartmentName,
        //                    Active = x.Active,                           
        //                    DivisionName = x.DivisionName
        //                });

        //    return View(list);

        //}

        // GET: Departments/Create
        public ActionResult CreateDepartmentWithDivision()
        {
            ViewBag.DivisionID = new SelectList(db.Divisions, "ID", "DivisionName");
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDepartmentWithDivision(Department department, Division division)
        {
            if (ModelState.IsValid)
            {
                db.Divisions.Add(division);
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DivisionID = new SelectList(db.Divisions, "ID", "DivisionName", department.DivisionID);
            return View(department);
        }

        // GET: Departments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            ViewBag.DivisionID = new SelectList(db.Divisions, "ID", "DivisionName");
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DepartmentName,Active,DivisionID,TimeStamp")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Departments.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DivisionID = new SelectList(db.Divisions, "ID", "DivisionName", department.DivisionID);
            return View(department);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            ViewBag.DivisionID = new SelectList(db.Divisions, "ID", "DivisionName", department.DivisionID);
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DepartmentName,Active,DivisionID,TimeStamp")] Department department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DivisionID = new SelectList(db.Divisions, "ID", "DivisionName", department.DivisionID);
            return View(department);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Department department = db.Departments.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = db.Departments.Find(id);
            db.Departments.Remove(department);
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
