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
    public class CampusController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Campus
        public ActionResult Index()
        {
            var campuses = db.Campuses.Include(c => c.Address);
            return View(campuses.ToList());
        }

        // Display Campuses with Address
        public ActionResult CampusWithAddress()
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



        // GET: CampusWithAddress
        public ActionResult DetailsCampusWithAddress(int? id)
        {
            var campus = db.Campuses.Include("Address").Where(x => x.ID == id).FirstOrDefault();
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            if( campus == null)
            {
                return HttpNotFound();
            }

            CampusWithAddressViewModels models = new CampusWithAddressViewModels()
            {
                CampusName = campus.CampusName,
                Active = campus.Active,
                City = campus.Address.City,
                State = campus.Address.State,
                StreetAddress = campus.Address.StreetAddress,
                ZIP = campus.Address.ZIP,
            };
            return View(models);
        
        }

        // GET: Campus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campus campus = db.Campuses.Find(id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            return View(campus);
        }

        // GET: Campus/Create
        public ActionResult Create()
        {
            ViewBag.AddressID = new SelectList(db.Addresses, "ID", "City");
            return View();
        }

        // POST: Campus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CampusName,AddressID,Active,TimeStamp")] Campus campus)
        {
            if (ModelState.IsValid)
            {
                db.Campuses.Add(campus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AddressID = new SelectList(db.Addresses, "ID", "City", campus.AddressID);
            return View(campus);
        }

        // GET: Campus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campus campus = db.Campuses.Find(id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "ID", "City", campus.AddressID);
            return View(campus);
        }

        // POST: Campus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CampusName,AddressID,Active,TimeStamp")] Campus campus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AddressID = new SelectList(db.Addresses, "ID", "City", campus.AddressID);
            return View(campus);
        }

        // GET: Campus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campus campus = db.Campuses.Find(id);
            if (campus == null)
            {
                return HttpNotFound();
            }
            return View(campus);
        }

        // POST: Campus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Campus campus = db.Campuses.Find(id);
            db.Campuses.Remove(campus);
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
