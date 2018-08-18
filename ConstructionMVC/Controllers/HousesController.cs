using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConstructionMVC;

namespace ConstructionMVC.Controllers
{
    public class HousesController : Controller
    {
        private ConstructionDBV1Entities db = new ConstructionDBV1Entities();

        // GET: Houses
        public ActionResult Index()
        {
            var houses = db.Houses.Include(h => h.Customer).Include(h => h.Location).Include(h => h.Type).Include(h => h.Location1).Include(h => h.Type1);
            return View(houses.ToList());
        }

        // GET: Houses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // GET: Houses/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName");
            ViewBag.Location_HouseID = new SelectList(db.Locations, "LocationID", "StreetName");
            ViewBag.Location_HouseID = new SelectList(db.Types, "TypeID", "Style");
            ViewBag.Location_HouseID = new SelectList(db.Locations, "LocationID", "StreetName");
            ViewBag.Location_HouseID = new SelectList(db.Types, "TypeID", "Style");
            return View();
        }

        // POST: Houses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Location_HouseID,Rooms,Floors,IsGarage,BuildDate,CustomerID,LocationID")] House house)
        {
            if (ModelState.IsValid)
            {
                db.Houses.Add(house);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", house.CustomerID);
            ViewBag.Location_HouseID = new SelectList(db.Locations, "LocationID", "StreetName", house.Location_HouseID);
            ViewBag.Location_HouseID = new SelectList(db.Types, "TypeID", "Style", house.Location_HouseID);
            ViewBag.Location_HouseID = new SelectList(db.Locations, "LocationID", "StreetName", house.Location_HouseID);
            ViewBag.Location_HouseID = new SelectList(db.Types, "TypeID", "Style", house.Location_HouseID);
            return View(house);
        }

        // GET: Houses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", house.CustomerID);
            ViewBag.Location_HouseID = new SelectList(db.Locations, "LocationID", "StreetName", house.Location_HouseID);
            ViewBag.Location_HouseID = new SelectList(db.Types, "TypeID", "Style", house.Location_HouseID);
            ViewBag.Location_HouseID = new SelectList(db.Locations, "LocationID", "StreetName", house.Location_HouseID);
            ViewBag.Location_HouseID = new SelectList(db.Types, "TypeID", "Style", house.Location_HouseID);
            return View(house);
        }

        // POST: Houses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Location_HouseID,Rooms,Floors,IsGarage,BuildDate,CustomerID,LocationID")] House house)
        {
            if (ModelState.IsValid)
            {
                db.Entry(house).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.Customers, "CustomerID", "FirstName", house.CustomerID);
            ViewBag.Location_HouseID = new SelectList(db.Locations, "LocationID", "StreetName", house.Location_HouseID);
            ViewBag.Location_HouseID = new SelectList(db.Types, "TypeID", "Style", house.Location_HouseID);
            ViewBag.Location_HouseID = new SelectList(db.Locations, "LocationID", "StreetName", house.Location_HouseID);
            ViewBag.Location_HouseID = new SelectList(db.Types, "TypeID", "Style", house.Location_HouseID);
            return View(house);
        }

        // GET: Houses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            House house = db.Houses.Find(id);
            if (house == null)
            {
                return HttpNotFound();
            }
            return View(house);
        }

        // POST: Houses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            House house = db.Houses.Find(id);
            db.Houses.Remove(house);
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
