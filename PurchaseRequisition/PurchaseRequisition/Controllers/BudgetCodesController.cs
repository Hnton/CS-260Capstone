using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using PurchaseRequisition.Models;
using PurchaseRequisition.Models.ViewModels;

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

        //// Display BudgetCodes with Amount
        //public ActionResult BudgetCodesWithAmount()
        //{
        //    var list = (from c in db.BudgetCodes
        //                join a in db.BudgetAmounts
        //                on c.ID equals a.ID into ThisList
        //                from a in ThisList.DefaultIfEmpty()
        //                select new
        //                {
        //                    DA_CODE = c.DA_CODE,
        //                    BudgetCodeName = c.BudgetCodeName,
        //                    Type = c.Type,
        //                    Active = c.Active,
        //                    TotalAmount = a.TotalAmount
                           

        //                }).ToList()
        //                .Select(x => new BudgetCodeWithAmountViewModels()
        //                {
        //                    DA_CODE = x.DA_CODE,
        //                    BudgetCodeName = x.BudgetCodeName,
        //                    Type = x.Type,
        //                    Active = x.Active,
        //                    TotalAmount = x.TotalAmount
        //                });

        //    return View(list);
        //}

        // GET: BudgetCodes/Create
        public ActionResult CreateBudgetAndAmount()
        {
            return View();
        }

        // POST: BudgetCodes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBudgetAndAmount(BudgetCode budgetCode, BudgetAmount budgetAmount)
        {
            if (ModelState.IsValid)
            {
                db.BudgetAmounts.Add(budgetAmount);
                db.BudgetCodes.Add(budgetCode);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(budgetCode);
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
