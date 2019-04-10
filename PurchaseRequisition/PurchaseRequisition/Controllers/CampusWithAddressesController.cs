using System;
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
    public class CampusWithAddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CampusWithAddresses
        public ActionResult Index()
        {
            return View(db.CampusWithAddresses.ToList());
        }

        // GET: CampusWithAddresses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampusWithAddress campusWithAddress = db.CampusWithAddresses.Find(id);
            if (campusWithAddress == null)
            {
                return HttpNotFound();
            }
            return View(campusWithAddress);
        }

        // GET: CampusWithAddresses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CampusWithAddresses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CampusName,AddressID,Active,City,State,StreetAddress,ZIP,TimeStamp")] CampusWithAddress campusWithAddress)
        {
            if (ModelState.IsValid)
            {
                db.CampusWithAddresses.Add(campusWithAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(campusWithAddress);
        }

        // GET: CampusWithAddresses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampusWithAddress campusWithAddress = db.CampusWithAddresses.Find(id);
            if (campusWithAddress == null)
            {
                return HttpNotFound();
            }
            return View(campusWithAddress);
        }

        // POST: CampusWithAddresses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CampusName,AddressID,Active,City,State,StreetAddress,ZIP,TimeStamp")] CampusWithAddress campusWithAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campusWithAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(campusWithAddress);
        }

        // GET: CampusWithAddresses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampusWithAddress campusWithAddress = db.CampusWithAddresses.Find(id);
            if (campusWithAddress == null)
            {
                return HttpNotFound();
            }
            return View(campusWithAddress);
        }

        // POST: CampusWithAddresses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CampusWithAddress campusWithAddress = db.CampusWithAddresses.Find(id);
            db.CampusWithAddresses.Remove(campusWithAddress);
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
