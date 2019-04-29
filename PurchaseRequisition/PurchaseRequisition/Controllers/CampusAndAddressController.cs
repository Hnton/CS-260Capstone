using PurchaseRequisition.Models;
using PurchaseRequisition.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurchaseRequisition.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CampusAndAddressController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CampusAndAddress
        public ActionResult Index()
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

        // GET: Campus/Create
        public ActionResult CreateCampusAndAddress()
        {
            ViewBag.AddressID = new SelectList(db.Addresses, "ID", "City");
            return View();
        }

        // POST: Campus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCampusAndAddress(Campus campus, Address address)
        {
            if (ModelState.IsValid)
            {
                db.Addresses.Add(address);
                db.Campuses.Add(campus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressID = new SelectList(db.Addresses, "ID", "City", campus.AddressID);
            return View(campus);
        }
    }
}