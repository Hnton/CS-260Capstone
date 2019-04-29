using PurchaseRequisition.Models;
using PurchaseRequisition.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurchaseRequisition.Controllers
{
    public class PurchaseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Purchase
        public ActionResult Index()
        {
            var list = (from o in db.Orders
                        join s in db.SupervisorApprovals
                        on o.ID equals s.ID
                        into ThisList
                        from s in ThisList.DefaultIfEmpty()
                        select new
                        {
                            EmployeeName = o.Employee.FirstName + " " + o.Employee.LastName,
                            SupervisorName = s.Employee.FirstName + " " + s.Employee.LastName,
                            StatusName = o.Status.StatusName,
                            CategoryName = o.Category.CategoryName,
                            BudgetCodeName = o.BudgetCode.BudgetCodeName,
                            DateMade = o.DateMade,
                            DateOrdered = o.DateOrdered,
                            StateContract = o.StateContract,
                            BusinessJustification = o.BusinessJustification

                        }).ToList()
                       .Select(x => new PurchaseReqWithReqestViewModels()
                       {
                           EmployeeName = x.EmployeeName,
                           SupervisorName = x.SupervisorName,
                           StatusName = x.StatusName,
                           CategoryName = x.CategoryName,
                           BudgetCodeName = x.BudgetCodeName,
                           DateMade = x.DateMade,
                           DateOrdered = x.DateOrdered,
                           StateContract = x.StateContract,
                           BusinessJustification = x.BusinessJustification
                       });

            return View(list);
        }
        // GET: Requests/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(db.Users, "Id", "Email");
            ViewBag.SupervisorID = new SelectList(db.Users, "Id", "Email");
            ViewBag.BudgetCodeID = new SelectList(db.BudgetCodes, "Id", "BudgetCodeName");
            ViewBag.StatusID = new SelectList(db.Statuses, "Id", "StatusName");
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryName");




            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order order, Item item, Request request)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.Items.Add(item);
                db.Requests.Add(request);
                request.EstimatedTotal = request.EstimatedCost * request.QuantityRequested;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StatusID = new SelectList(db.Statuses, "Id", "StatusName");
            ViewBag.BudgetCodeID = new SelectList(db.BudgetCodes, "Id", "BudgetCodeName");
            ViewBag.EmployeeID = new SelectList(db.Users, "Id", "Email");
            ViewBag.SupervisorID = new SelectList(db.Users, "Id", "Email");
            return View(request);
        }
    }
}