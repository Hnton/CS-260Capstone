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
    public class EmployeesBudgetCodesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: EmployeesBudgetCodes
        public ActionResult Index()
        {
            var employeesBudgetCodes = db.EmployeesBudgetCodes.Include(e => e.BudgetCode).Include(e => e.Employee);
            return View(employeesBudgetCodes.ToList());
        }

        // GET: EmployeesBudgetCodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeesBudgetCodes employeesBudgetCodes = db.EmployeesBudgetCodes.Find(id);
            if (employeesBudgetCodes == null)
            {
                return HttpNotFound();
            }
            return View(employeesBudgetCodes);
        }

        // GET: EmployeesBudgetCodes/Create
        public ActionResult Create()
        {
            ViewBag.BudgetCodeID = new SelectList(db.BudgetCodes, "ID", "BudgetCodeName");
            ViewBag.EmployeeID = new SelectList(db.Users, "Id", "Email");
            return View();
        }

        // POST: EmployeesBudgetCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmployeeID,Active,BudgetCodeID,TimeStamp")] EmployeesBudgetCodes employeesBudgetCodes)
        {
            if (ModelState.IsValid)
            {
                db.EmployeesBudgetCodes.Add(employeesBudgetCodes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BudgetCodeID = new SelectList(db.BudgetCodes, "ID", "BudgetCodeName", employeesBudgetCodes.BudgetCodeID);
            ViewBag.EmployeeID = new SelectList(db.Users, "Id", "Email", employeesBudgetCodes.EmployeeID);
            return View(employeesBudgetCodes);
        }

        // GET: EmployeesBudgetCodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeesBudgetCodes employeesBudgetCodes = db.EmployeesBudgetCodes.Find(id);
            if (employeesBudgetCodes == null)
            {
                return HttpNotFound();
            }
            ViewBag.BudgetCodeID = new SelectList(db.BudgetCodes, "ID", "BudgetCodeName", employeesBudgetCodes.BudgetCodeID);
            ViewBag.EmployeeID = new SelectList(db.Users, "Id", "Email", employeesBudgetCodes.EmployeeID);
            return View(employeesBudgetCodes);
        }

        // POST: EmployeesBudgetCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmployeeID,Active,BudgetCodeID,TimeStamp")] EmployeesBudgetCodes employeesBudgetCodes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeesBudgetCodes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BudgetCodeID = new SelectList(db.BudgetCodes, "ID", "BudgetCodeName", employeesBudgetCodes.BudgetCodeID);
            ViewBag.EmployeeID = new SelectList(db.Users, "Id", "Email", employeesBudgetCodes.EmployeeID);
            return View(employeesBudgetCodes);
        }

        // GET: EmployeesBudgetCodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeesBudgetCodes employeesBudgetCodes = db.EmployeesBudgetCodes.Find(id);
            if (employeesBudgetCodes == null)
            {
                return HttpNotFound();
            }
            return View(employeesBudgetCodes);
        }

        // POST: EmployeesBudgetCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeesBudgetCodes employeesBudgetCodes = db.EmployeesBudgetCodes.Find(id);
            db.EmployeesBudgetCodes.Remove(employeesBudgetCodes);
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
