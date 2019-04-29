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
    [Authorize(Roles ="Admin")]
    public class SupervisorApprovalsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SupervisorApprovals
        public ActionResult Index()
        {
            var supervisorApprovals = db.SupervisorApprovals.Include(s => s.Approval).Include(s => s.Employee).Include(s => s.Order);
            return View(supervisorApprovals.ToList());
        }

        // GET: SupervisorApprovals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupervisorApproval supervisorApproval = db.SupervisorApprovals.Find(id);
            if (supervisorApproval == null)
            {
                return HttpNotFound();
            }
            return View(supervisorApproval);
        }

        // GET: SupervisorApprovals/Create
        public ActionResult Create()
        {
            ViewBag.ApprovalID = new SelectList(db.Approval, "ID", "ApprovalName");
            ViewBag.SupervisorID = new SelectList(db.Users, "Id", "Email");
            ViewBag.OrderID = new SelectList(db.Orders, "ID", "BusinessJustification");
            return View();
        }

        // POST: SupervisorApprovals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ApprovalID,OrderID,SupervisorID,DeniedJustification,TimeStamp")] SupervisorApproval supervisorApproval)
        {
            if (ModelState.IsValid)
            {
                db.SupervisorApprovals.Add(supervisorApproval);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApprovalID = new SelectList(db.Approval, "ID", "ApprovalName", supervisorApproval.ApprovalID);
            ViewBag.SupervisorID = new SelectList(db.Users, "Id", "Email", supervisorApproval.SupervisorID);
            ViewBag.OrderID = new SelectList(db.Orders, "ID", "BusinessJustification", supervisorApproval.OrderID);
            return View(supervisorApproval);
        }

        // GET: SupervisorApprovals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupervisorApproval supervisorApproval = db.SupervisorApprovals.Find(id);
            if (supervisorApproval == null)
            {
                return HttpNotFound();
            }
            ViewBag.ApprovalID = new SelectList(db.Approval, "ID", "ApprovalName", supervisorApproval.ApprovalID);
            ViewBag.SupervisorID = new SelectList(db.Users, "Id", "Email", supervisorApproval.SupervisorID);
            ViewBag.OrderID = new SelectList(db.Orders, "ID", "BusinessJustification", supervisorApproval.OrderID);
            return View(supervisorApproval);
        }

        // POST: SupervisorApprovals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ApprovalID,OrderID,SupervisorID,DeniedJustification,TimeStamp")] SupervisorApproval supervisorApproval)
        {
            if (ModelState.IsValid)
            {
                db.Entry(supervisorApproval).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ApprovalID = new SelectList(db.Approval, "ID", "ApprovalName", supervisorApproval.ApprovalID);
            ViewBag.SupervisorID = new SelectList(db.Users, "Id", "Email", supervisorApproval.SupervisorID);
            ViewBag.OrderID = new SelectList(db.Orders, "ID", "BusinessJustification", supervisorApproval.OrderID);
            return View(supervisorApproval);
        }

        // GET: SupervisorApprovals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SupervisorApproval supervisorApproval = db.SupervisorApprovals.Find(id);
            if (supervisorApproval == null)
            {
                return HttpNotFound();
            }
            return View(supervisorApproval);
        }

        // POST: SupervisorApprovals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SupervisorApproval supervisorApproval = db.SupervisorApprovals.Find(id);
            db.SupervisorApprovals.Remove(supervisorApproval);
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
