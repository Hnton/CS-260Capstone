using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PurchaseRequisition.Models;
using PurchaseRequisition.Models.ViewModels;

namespace PurchaseRequisition.Controllers
{
    public class SupervisorController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // Display SupervisorApproval with Approval
        public ActionResult SupervisorApprovalWithApproval()
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
    }
}