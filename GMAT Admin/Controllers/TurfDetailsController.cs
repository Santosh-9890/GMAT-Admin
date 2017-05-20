using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GMAT_Admin;
using GMAT_Admin.Models;

namespace GMAT_Admin.Controllers
{
    public class TurfDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TurfDetails
        public ActionResult Index()
        {
            return View(db.TurfDetails.ToList());
        }

        // GET: TurfDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TurfDetail turfDetail = db.TurfDetails.Find(id);
            if (turfDetail == null)
            {
                return HttpNotFound();
            }
            return View(turfDetail);
        }

        // GET: TurfDetails/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TurfDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TurfId,TurfCode,TurfName,TurfEmailId,Address,Synopsis,MobileNo,PhoneNo,Dimensions,AvailableFrom,AvailableTill,DayCharges,NightCharges,RegionCode")] TurfDetail turfDetail)
        {
            if (ModelState.IsValid)
            {
                db.TurfDetails.Add(turfDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(turfDetail);
        }

        // GET: TurfDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TurfDetail turfDetail = db.TurfDetails.Find(id);
            if (turfDetail == null)
            {
                return HttpNotFound();
            }
            return View(turfDetail);
        }

        // POST: TurfDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TurfId,TurfCode,TurfName,TurfEmailId,Address,Synopsis,MobileNo,PhoneNo,Dimensions,AvailableFrom,AvailableTill,DayCharges,NightCharges,RegionCode")] TurfDetail turfDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turfDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(turfDetail);
        }

        // GET: TurfDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TurfDetail turfDetail = db.TurfDetails.Find(id);
            if (turfDetail == null)
            {
                return HttpNotFound();
            }
            return View(turfDetail);
        }

        // POST: TurfDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TurfDetail turfDetail = db.TurfDetails.Find(id);
            db.TurfDetails.Remove(turfDetail);
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
