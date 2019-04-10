using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PurchaseRequisition.Models;

namespace PurchaseRequisition.Models.ViewModels
{
    public class BudgetCodeWithBudgetAmountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BudgetCodeWithBudgetAmounts
        public ActionResult Index()
        {
            return View(db.BudgetCodeWithBudgetAmounts.ToList());
        }

        // GET: BudgetCodeWithBudgetAmounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetCodeWithBudgetAmount budgetCodeWithBudgetAmount = db.BudgetCodeWithBudgetAmounts.Find(id);
            if (budgetCodeWithBudgetAmount == null)
            {
                return HttpNotFound();
            }
            return View(budgetCodeWithBudgetAmount);
        }

        // GET: BudgetCodeWithBudgetAmounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BudgetCodeWithBudgetAmounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DA_CODE,BudgetCodeName,Type,Active,TotalAmount,TimeStamp")] BudgetCodeWithBudgetAmount budgetCodeWithBudgetAmount)
        {
            if (ModelState.IsValid)
            {
                db.BudgetCodeWithBudgetAmounts.Add(budgetCodeWithBudgetAmount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(budgetCodeWithBudgetAmount);
        }

        // GET: BudgetCodeWithBudgetAmounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetCodeWithBudgetAmount budgetCodeWithBudgetAmount = db.BudgetCodeWithBudgetAmounts.Find(id);
            if (budgetCodeWithBudgetAmount == null)
            {
                return HttpNotFound();
            }
            return View(budgetCodeWithBudgetAmount);
        }

        // POST: BudgetCodeWithBudgetAmounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,DA_CODE,BudgetCodeName,Type,Active,TotalAmount,TimeStamp")] BudgetCodeWithBudgetAmount budgetCodeWithBudgetAmount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(budgetCodeWithBudgetAmount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(budgetCodeWithBudgetAmount);
        }

        // GET: BudgetCodeWithBudgetAmounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetCodeWithBudgetAmount budgetCodeWithBudgetAmount = db.BudgetCodeWithBudgetAmounts.Find(id);
            if (budgetCodeWithBudgetAmount == null)
            {
                return HttpNotFound();
            }
            return View(budgetCodeWithBudgetAmount);
        }

        // POST: BudgetCodeWithBudgetAmounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BudgetCodeWithBudgetAmount budgetCodeWithBudgetAmount = db.BudgetCodeWithBudgetAmounts.Find(id);
            db.BudgetCodeWithBudgetAmounts.Remove(budgetCodeWithBudgetAmount);
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
