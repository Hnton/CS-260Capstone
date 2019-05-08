using PurchaseRequisition.Models;
using PurchaseRequisition.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurchaseRequisition.Controllers
{
    [Authorize(Roles = "Auditor")]
    public class AuditorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        // GET: Auditor
        public ActionResult viewCampuses()
        {
            var list = (from c in db.Campuses
                        join a in db.Addresses
                        on c.ID equals a.ID into ThisList
                        from a in ThisList.DefaultIfEmpty()
                        select new
                        {
                            CampusName = c.CampusName,
                            Active = c.Active,
                            City = a.City,
                            State = a.State,
                            StreetAddress = a.StreetAddress,
                            ZIP = a.ZIP

                        }).ToList()
                        .Select(x => new CampusWithAddressViewModels()
                        {
                            CampusName = x.CampusName,
                            Active = x.Active,
                            City = x.City,
                            State = x.State,
                            StreetAddress = x.StreetAddress,
                            ZIP = x.ZIP
                        });

            return View(list);
        }

        public ActionResult viewDepartments()
        {

            var list = (from d in db.Departments
                        join div in db.Divisions
                        on d.ID equals div.ID into ThisList
                        from div in ThisList.DefaultIfEmpty()
                        select new
                        {
                            DepartmentName = d.DepartmentName,
                            Active = d.Active,
                            DivisionName = div.DivisionName


                        }).ToList()
                        .Select(x => new DepartmentWithDivisionViewModels()
                        {
                            DepartmentName = x.DepartmentName,
                            Active = x.Active,
                            DivisionName = x.DivisionName
                        });

            return View(list);
        }

        public ActionResult viewBudgets()
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

        public ActionResult viewOrders()
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

        public ActionResult viewVendors()
        {
            var list = (from v in db.Vendors
                        join a in db.Addresses
                        on v.AddressID equals a.ID into ThisList
                        from a in ThisList.DefaultIfEmpty()
                        select new
                        {
                            VendorName = v.VendorName,
                            Phone = v.Phone,
                            Fax = v.Fax,
                            Website = v.Website,
                            City = a.City,
                            State = a.State,
                            StreetAddress = a.StreetAddress,
                            ZIP = a.ZIP


                        }).ToList()
                        .Select(x => new VendorWithAddressViewModels()
                        {
                            VendorName = x.VendorName,
                            Phone = x.Phone,
                            Fax = x.Fax,
                            Website = x.Website,
                            City = x.City,
                            State = x.State,
                            StreetAddress = x.StreetAddress,
                            ZIP = x.ZIP
                        });

            return View(list);
        }

        public ActionResult viewUsers()
        {
            var query = db.Employees.ToList();

            return View(query);
        }
    }
}