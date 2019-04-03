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
    public class BudgetAmountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BudgetAmounts
        public ActionResult Index()
        {
            var budgetAmounts = db.BudgetAmounts.Include(b => b.BudgetCode);
            return View(budgetAmounts.ToList());
        }

        // GET: BudgetAmounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetAmount budgetAmount = db.BudgetAmounts.Find(id);
            if (budgetAmount == null)
            {
                return HttpNotFound();
            }
            return View(budgetAmount);
        }

        // GET: BudgetAmounts/Create
        public ActionResult Create()
        {
            ViewBag.BudgetCodeID = new SelectList(db.BudgetCodes, "ID", "BudgetCodeName");
            return View();
        }

        // POST: BudgetAmounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TotalAmount,BudgetCodeID,TimeStamp")] BudgetAmount budgetAmount)
        {
            if (ModelState.IsValid)
            {
                db.BudgetAmounts.Add(budgetAmount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BudgetCodeID = new SelectList(db.BudgetCodes, "ID", "BudgetCodeName", budgetAmount.BudgetCodeID);
            return View(budgetAmount);
        }

        // GET: BudgetAmounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetAmount budgetAmount = db.BudgetAmounts.Find(id);
            if (budgetAmount == null)
            {
                return HttpNotFound();
            }
            ViewBag.BudgetCodeID = new SelectList(db.BudgetCodes, "ID", "BudgetCodeName", budgetAmount.BudgetCodeID);
            return View(budgetAmount);
        }

        // POST: BudgetAmounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TotalAmount,BudgetCodeID,TimeStamp")] BudgetAmount budgetAmount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(budgetAmount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BudgetCodeID = new SelectList(db.BudgetCodes, "ID", "BudgetCodeName", budgetAmount.BudgetCodeID);
            return View(budgetAmount);
        }

        // GET: BudgetAmounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BudgetAmount budgetAmount = db.BudgetAmounts.Find(id);
            if (budgetAmount == null)
            {
                return HttpNotFound();
            }
            return View(budgetAmount);
        }

        // POST: BudgetAmounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BudgetAmount budgetAmount = db.BudgetAmounts.Find(id);
            db.BudgetAmounts.Remove(budgetAmount);
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
