using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PurchaseRequisition.Models;
using System;
using System.Web.Mvc;

namespace PurchaseRequisition.Controllers
{
    public class HomeController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
       
    }
}