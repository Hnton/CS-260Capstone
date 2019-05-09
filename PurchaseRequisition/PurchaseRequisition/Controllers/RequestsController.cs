﻿using System;
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
    public class RequestsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Requests
        public ActionResult Index(string bus)
        {

            var requests = db.Requests.Where(i=> i.Order.BusinessJustification.Equals(bus)).Include(r => r.Item).Include(r => r.Order).Include(r => r.Vendor);
            ViewBag.TotalEstimatedAmount = db.Requests.Where(e => e.Order.BusinessJustification.Equals(bus)).Sum(s => s.EstimatedTotal);
            ViewBag.TotalPaidAmount = db.Requests.Where(e => e.Order.BusinessJustification.Equals(bus)).Sum(s => s.PaidTotal);
            return View(requests.ToList());
        }

        public ActionResult PurchaseReqWithRequest()
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

        public ActionResult RequestWithVendor()
        {
            var list = (from r in db.Requests
                        join v in db.Vendors
                        on r.VendorID equals v.ID
                        into ThisList
                        from v in ThisList.DefaultIfEmpty()
                        select new
                        {
                            QuantityRequested = r.QuantityRequested,
                            EstimatedCost = r.EstimatedCost,
                            EstimatedTotal = r.EstimatedTotal,
                            PaidCost = r.PaidCost,
                            PaidTotal = r.PaidTotal,
                            Chosen = r.Chosen,
                            orderID = r.OrderID,
                            Attachments = r.Attachments,
                            ItemName = r.Item.ItemName,
                            Description = r.Item.Description,
                            ReasonChosen = r.ReasonChosen,
                            VendorName = v.VendorName
                        }).ToList()
                       .Select(x => new RequestWithVendorViewModels()
                       {
                           QuantityRequested = x.QuantityRequested,
                           EstimatedCost = x.EstimatedCost,
                           EstimatedTotal = x.EstimatedTotal,
                           PaidCost = x.PaidCost,
                           PaidTotal = x.PaidTotal,
                           Chosen = x.Chosen,
                           orderID = x.orderID,
                           //Attachments = x.Attachments,
                           ItemName = x.ItemName,
                           Description = x.Description,
                           ReasonChosen = x.ReasonChosen,
                           VendorName = x.VendorName
                       });

            return View(list);

        }

        // GET: Requests/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // GET: Requests/Create
        public ActionResult Create()
        {
            ViewBag.ItemID = new SelectList(db.Items, "ID", "ItemName");
            ViewBag.OrderID = new SelectList(db.Orders, "ID", "BusinessJustification");
            ViewBag.VendorID = new SelectList(db.Vendors, "ID", "VendorName");
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,QuantityRequested,EstimatedCost,EstimatedTotal,PaidCost,PaidTotal,Chosen,OrderID,VendorID,ItemID,ReasonChosen,TimeStamp")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Requests.Add(request);
                request.EstimatedTotal = request.EstimatedCost * request.QuantityRequested;
               
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ItemID = new SelectList(db.Items, "ID", "ItemName", request.ItemID);
            ViewBag.OrderID = new SelectList(db.Orders, "ID", "BusinessJustification", request.OrderID);
            ViewBag.VendorID = new SelectList(db.Vendors, "ID", "VendorName", request.VendorID);
            return View(request);
        }

        // GET: Requests/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            ViewBag.ItemID = new SelectList(db.Items, "ID", "ItemName", request.ItemID);
            ViewBag.OrderID = new SelectList(db.Orders, "ID", "BusinessJustification", request.OrderID);
            ViewBag.VendorID = new SelectList(db.Vendors, "ID", "VendorName", request.VendorID);
            return View(request);
        }

        // POST: Requests/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,QuantityRequested,EstimatedCost,EstimatedTotal,PaidCost,PaidTotal,Chosen,OrderID,VendorID,ItemID,ReasonChosen,TimeStamp")] Request request)
        {
            if (ModelState.IsValid)
            {
                db.Entry(request).State = EntityState.Modified;
                request.PaidTotal = request.PaidCost * request.QuantityRequested;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ItemID = new SelectList(db.Items, "ID", "ItemName", request.ItemID);
            ViewBag.OrderID = new SelectList(db.Orders, "ID", "BusinessJustification", request.OrderID);
            ViewBag.VendorID = new SelectList(db.Vendors, "ID", "VendorName", request.VendorID);
            return View(request);
        }

        // GET: Requests/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            return View(request);
        }

        // POST: Requests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Request request = db.Requests.Find(id);
            db.Requests.Remove(request);
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
