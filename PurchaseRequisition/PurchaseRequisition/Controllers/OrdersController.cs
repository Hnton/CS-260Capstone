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
    public class OrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            var orders = db.Orders.Include(o => o.BudgetCode).Include(o => o.Category).Include(o => o.Employee).Include(o => o.Status);
            return View(orders.ToList());
        }

        public ActionResult _Approved()
        {
            var orders = db.Orders.Include(o => o.BudgetCode).Include(o => o.Category).Include(o => o.Employee).Include(o => o.Status).Where(i => i.Status.StatusName.Equals("Approved"));

            return PartialView(orders.ToList());
        }

        public ActionResult _Denied()
        {
            var orders = db.Orders.Include(o => o.BudgetCode).Include(o => o.Category).Include(o => o.Employee).Include(o => o.Status).Where(i => i.Status.StatusName.Equals("Denied"));

            return PartialView(orders.ToList());
        }

        public ActionResult _Cancelled()
        {
            var orders = db.Orders.Include(o => o.BudgetCode).Include(o => o.Category).Include(o => o.Employee).Include(o => o.Status).Where(i => i.Status.StatusName.Equals("Cancelled"));

            return PartialView(orders.ToList());
        }

        public ActionResult _Pending()
        {
            var orders = db.Orders.Include(o => o.BudgetCode).Include(o => o.Category).Include(o => o.Employee).Include(o => o.Status).Where(i => i.Status.StatusName.Equals("Pending"));

            return PartialView(orders.ToList());
        }

        // GET: Orders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.BudgetCodeID = new SelectList(db.BudgetCodes, "ID", "BudgetCodeName");
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "CategoryName");
            ViewBag.EmployeeID = new SelectList(db.Users, "Id", "Email");
            ViewBag.StatusID = new SelectList(db.Statuses, "ID", "StatusName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,DateMade,DateOrdered,StateContract,BusinessJustification,EmployeeID,StatusID,CategoryID,BudgetCodeID,TimeStamp")] Order order)
        {
            if (ModelState.IsValid)
            {
                db.Orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Create", "Items");
            }

            ViewBag.BudgetCodeID = new SelectList(db.BudgetCodes, "ID", "BudgetCodeName", order.BudgetCodeID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "CategoryName", order.CategoryID);
            //ViewBag.EmployeeID = new SelectList(db.Users, "Id", "Email", order.EmployeeID);
            ViewBag.StatusID = new SelectList(db.Statuses, "ID", "StatusName", order.StatusID);
            return View(order);
        }

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            ViewBag.BudgetCodeID = new SelectList(db.BudgetCodes, "ID", "BudgetCodeName", order.BudgetCodeID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "CategoryName", order.CategoryID);
            ViewBag.EmployeeID = new SelectList(db.Users, "Id", "Email", order.EmployeeID);
            ViewBag.StatusID = new SelectList(db.Statuses, "ID", "StatusName", order.StatusID);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;

                order.DateMade = DateTime.Now;
                order.DateOrdered = DateTime.Now;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            ViewBag.BudgetCodeID = new SelectList(db.BudgetCodes, "ID", "BudgetCodeName", order.BudgetCodeID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "CategoryName", order.CategoryID);
            ViewBag.EmployeeID = new SelectList(db.Users, "Id", "Email", order.EmployeeID);
            ViewBag.StatusID = new SelectList(db.Statuses, "ID", "StatusName", order.StatusID);
            return View(order);
        }

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Order order = db.Orders.Find(id);
            db.Orders.Remove(order);
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
