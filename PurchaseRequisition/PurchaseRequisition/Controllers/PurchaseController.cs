using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using PurchaseRequisition.Models;
using PurchaseRequisition.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PurchaseRequisition.Controllers
{
    public class PurchaseController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "Purchasing")]
        public ActionResult Approved()
        {
            var list = (from o in db.Orders
                        where o.Status.StatusName.Equals("Approved")
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
        [Authorize(Roles = "User, Admin, Supervisor")]
        // GET: Purchase
        public ActionResult Index()
        {
            var list = (from o in db.Orders
                        where o.Employee.Email == User.Identity.Name
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
        [Authorize(Roles = "User, Admin, Supervisor")]
        public ActionResult ItemWithVendor()
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
               Attachments = x.Attachments,
               ItemName = x.ItemName,
               Description = x.Description,
               ReasonChosen = x.ReasonChosen,
               VendorName = x.VendorName
           });

            return View(list);
        }
        [Authorize(Roles = "User, Admin, Supervisor")]
        public ActionResult Pending()
        {
            return View();
        }
        [Authorize(Roles = "User, Admin, Supervisor")]
        // GET: Requests/Create
        public ActionResult CreateWithVendor()
        {
            //var last = db.Orders.OrderByDescending(p => p.DateMade).FirstOrDefault();
            ViewBag.ItemID = new SelectList(db.Items, "ID", "ItemName");
            //ViewBag.OrderID = new SelectList(last.BusinessJustification.ToString(), "ID", "BusinessJustification");
            //ViewBag.OrderID = new SelectList(db.Orders.LastOrDefault().ToString(), "ID","BusinessJustification");
            ViewBag.VendorID = new SelectList(db.Vendors, "ID", "VendorName");
            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "User, Admin, Supervisor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateWithVendor(Request request, Item item, string button)
        {
            
                if (ModelState.IsValid)
                {
                var test = db.Orders.OrderByDescending(t => t.ID).First();

                request.OrderID = test.ID;


                    db.Items.Add(item);
                    db.Requests.Add(request);
                    request.EstimatedTotal = request.EstimatedCost * request.QuantityRequested;
                    request.PaidTotal = request.PaidCost * request.QuantityRequested;
                    


                    db.SaveChanges();

                    return RedirectToAction("Pending");
                }


            //var last = db.Orders.OrderByDescending(p => p.DateMade).FirstOrDefault();
            ViewBag.ItemID = new SelectList(db.Items, "ID", "ItemName");
            //ViewBag.OrderID = new SelectList(last.BusinessJustification.ToString(), "ID", "BusinessJustification");
            //ViewBag.OrderID = new SelectList(db.Orders.LastOrDefault().ToString(), "ID","BusinessJustification");
            ViewBag.VendorID = new SelectList(db.Vendors, "ID", "VendorName");
            return View(item);
        }

        // GET: Requests/Create
        [Authorize(Roles = "User, Admin, Supervisor")]
        public ActionResult Create()
        {
            var roleManager = new Microsoft.AspNet.Identity.RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            string Supervisor = roleManager.FindByName("Supervisor").Id;

            ViewBag.EmployeeID = new SelectList(db.Users.Where(i => i.Email.Equals(HttpContext.User.Identity.Name.ToString())), "ID", "Email");
            ViewBag.SupervisorID = new SelectList(db.Users.Where(u => u.Roles.Any(r => r.RoleId == Supervisor)).ToList(), "ID", "Email");


            ViewBag.BudgetCodeID = new SelectList(db.BudgetCodes, "Id", "BudgetCodeName");
            ViewBag.StatusID = new SelectList(db.Statuses.Where(s => s.StatusName == "Pending"), "Id", "StatusName");
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "CategoryName");


            return View();
        }

        // POST: Requests/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "User, Admin, Supervisor")]
        public ActionResult Create(Order order, Item item,Request request)
        {
            if (ModelState.IsValid)
            {
                order.DateMade = DateTime.Now;

                db.Orders.Add(order);
                db.Items.Add(item);
                db.Requests.Add(request);
                

                db.SaveChanges();
                db.Items.Remove(item);
                db.SaveChanges();
                return RedirectToAction("CreateWithVendor");
            }

            var roleManager = new Microsoft.AspNet.Identity.RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            string Supervisor = roleManager.FindByName("Supervisor").Id;

            ViewBag.StatusID = new SelectList(db.Statuses.Where(s => s.StatusName == "Pending"), "Id", "StatusName");
            ViewBag.BudgetCodeID = new SelectList(db.BudgetCodes, "Id", "BudgetCodeName");
            ViewBag.EmployeeID = new SelectList(db.Users.Where(i => i.Email.Equals(HttpContext.User.Identity.Name.ToString())), "ID", "Email");
            ViewBag.SupervisorID = new SelectList(db.Users.Where(u => u.Roles.Any(r => r.RoleId == Supervisor)).ToList(), "ID", "Email");
            return View(request);
        }

        // GET: Orders/Edit/5
        [Authorize(Roles = "User, Admin, Supervisor")]
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
        [Authorize(Roles = "User, Admin, Supervisor")]
        public ActionResult Edit( Order order)
        {
            if (ModelState.IsValid)
            {
                db.Entry(order).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BudgetCodeID = new SelectList(db.BudgetCodes, "ID", "BudgetCodeName", order.BudgetCodeID);
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "CategoryName", order.CategoryID);
            ViewBag.EmployeeID = new SelectList(db.Users, "Id", "Email", order.EmployeeID);
            ViewBag.StatusID = new SelectList(db.Statuses, "ID", "StatusName", order.StatusID);
            return View(order);
        }

    }
}