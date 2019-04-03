using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PurchaseRequisition.Models;

namespace PurchaseRequisition.Controllers
{
    public class BudgetCodesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BudgetCodes
        public ActionResult Index()
        {
            return View(db.BudgetCodes.ToList());
        }

        // GET: BudgetCodes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetCode budgetCode = db.BudgetCodes.Find(id);
            if (budgetCode == null)
            {
                return HttpNotFound();
            }
            return View(budgetCode);
        }

        // GET: BudgetCodes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BudgetCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DA_CODE,BudgetCodeName,Type,Active,TimeStamp")] BudgetCode budgetCode)
        {
            if (ModelState.IsValid)
            {
                db.BudgetCodes.Add(budgetCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(budgetCode);
        }

        // GET: BudgetCodes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetCode budgetCode = db.BudgetCodes.Find(id);
            if (budgetCode == null)
            {
                return HttpNotFound();
            }
            return View(budgetCode);
        }

        // POST: BudgetCodes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DA_CODE,BudgetCodeName,Type,Active,TimeStamp")] BudgetCode budgetCode)
        {
            if (ModelState.IsValid)
            {
                db.Entry(budgetCode).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(budgetCode);
        }

        // GET: BudgetCodes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetCode budgetCode = db.BudgetCodes.Find(id);
            if (budgetCode == null)
            {
                return HttpNotFound();
            }
            return View(budgetCode);
        }

        // POST: BudgetCodes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BudgetCode budgetCode = db.BudgetCodes.Find(id);
            db.BudgetCodes.Remove(budgetCode);
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
