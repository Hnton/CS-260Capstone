using PurchaseRequisition.Models;
using PurchaseRequisition.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PurchaseRequisition.Controllers
{
    public class BudgetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Admin, CFO")]
        // Display BudgetCodes with Amount
        public ActionResult Index()
        {
            var list = (from c in db.BudgetCodes
                        join a in db.BudgetAmounts
                        on c.ID equals a.ID into ThisList
                        from a in ThisList.DefaultIfEmpty()
                        select new
                        {
                            DA_CODE = c.DA_CODE,
                            BudgetCodeName = c.BudgetCodeName,
                            Type = c.Type,
                            Active = c.Active,
                            TotalAmount = a.TotalAmount


                        }).ToList()
                        .Select(x => new BudgetCodeWithAmountViewModels()
                        {
                            DA_CODE = x.DA_CODE,
                            BudgetCodeName = x.BudgetCodeName,
                            Type = x.Type,
                            Active = x.Active,
                            TotalAmount = x.TotalAmount
                        });

            return View(list);
        }

        public ActionResult CreateBudgetAndAmount()
        {
            return View();
        }


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