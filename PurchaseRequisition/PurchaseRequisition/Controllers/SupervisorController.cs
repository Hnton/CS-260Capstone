using PurchaseRequisition.Models;
using PurchaseRequisition.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurchaseRequisition.Controllers
{
    [Authorize(Roles ="Admin")]
    public class SupervisorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Supervisor
        public ActionResult Index()
        {
            var list = (from a in db.SupervisorApprovals
                        join e in db.Employees
                        on a.SupervisorID equals e.Id into ThisList
                        from e in ThisList.DefaultIfEmpty()
                        select new
                        {
                            ApprovalName = a.Approval.ApprovalName,
                            SupervisorName = e.FirstName + " " + e.LastName,
                            DeniedJustification = a.DeniedJustification

                        }).ToList()
                        .Select(x => new SupervisorApprovalWithApprovalViewModels()
                        {
                            ApprovalName = x.ApprovalName,
                            SupervisorName = x.SupervisorName,
                            DeniedJustification = x.DeniedJustification
                        });

            return View(list);
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
        public ActionResult Create(SupervisorApproval supervisorApproval, Approval approval)
        {
            if (ModelState.IsValid)
            {
                db.Approval.Add(approval);
                db.SupervisorApprovals.Add(supervisorApproval);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ApprovalID = new SelectList(db.Approval, "ID", "ApprovalName", supervisorApproval.ApprovalID);
            ViewBag.SupervisorID = new SelectList(db.Users, "Id", "Email", supervisorApproval.SupervisorID);
            ViewBag.OrderID = new SelectList(db.Orders, "ID", "BusinessJustification", supervisorApproval.OrderID);
            return View(supervisorApproval);
        }

    }
}