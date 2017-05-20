using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GMAT_Admin.Models;

namespace GMAT_Admin.Controllers
{
    public class BookingSlotsController : Controller
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        // GET: BookingSlots
        public ActionResult Index()
        {
            return View(db.BookingSlots.ToList());
        }

        // GET: BookingSlots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingSlots bookingSlots = db.BookingSlots.Find(id);
            if (bookingSlots == null)
            {
                return HttpNotFound();
            }
            return View(bookingSlots);
        }

        // GET: BookingSlots/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookingSlots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TurfCode,UserEmailId,FullName,BookingSlotFrom,BookingSlotTo,InvoiceNo,BookingDate,ChargesPaid,Token")] BookingSlots bookingSlots)
        {
            if (ModelState.IsValid)
            {
                db.BookingSlots.Add(bookingSlots);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookingSlots);
        }

        // GET: BookingSlots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingSlots bookingSlots = db.BookingSlots.Find(id);
            if (bookingSlots == null)
            {
                return HttpNotFound();
            }
            return View(bookingSlots);
        }

        // POST: BookingSlots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TurfCode,UserEmailId,FullName,BookingSlotFrom,BookingSlotTo,InvoiceNo,BookingDate,ChargesPaid,Token")] BookingSlots bookingSlots)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingSlots).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookingSlots);
        }

        // GET: BookingSlots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingSlots bookingSlots = db.BookingSlots.Find(id);
            if (bookingSlots == null)
            {
                return HttpNotFound();
            }
            return View(bookingSlots);
        }

        // POST: BookingSlots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingSlots bookingSlots = db.BookingSlots.Find(id);
            db.BookingSlots.Remove(bookingSlots);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: api/BookingSlots
        public ActionResult GetBookingSlots(DateTime fromDate, DateTime toDate)
        {
            //list<TurfDetails> turfs = new list<TurfDetails>();
            // List<TurfDetails> turfs = new List<TurfDetails>();
            IQueryable<BookingSlots> turfs = null;
            using (var context = new ApplicationDbContext())
            {
                turfs = from b in context.BookingSlots
                        where b.TurfCode == "" && b.BookingSlotFrom.Date.ToShortDateString() == DateTime.Now.Date.ToShortDateString()
                        select b;
            }

            //lstRequiredTurfDetails= lstTurfDetails.Where(x=>x.AvailableFrom)
            return RedirectToAction("Index");
        }

        //Get slots based on booking date 
        [HttpPost]
        public ViewResult GetBookedDateSlot(string bookedDate)
        {
            db = new ApplicationDbContext();
            //list<TurfDetails> turfs = new list<TurfDetails>();
            // List<TurfDetails> turfs = new List<TurfDetails>();
            List<BookingSlots> turfs = null;
            using (var context = new ApplicationDbContext())
            {
                //turfs = from b in context.BookingSlots
                //        where b.TurfCode == "" && b.BookingDate.Date.ToShortDateString() == bookedDate
                //        select b;
                

                turfs = context.BookingSlots.ToList().Where(x =>x.BookingDate.Date.ToString("MM/dd/yyyy") == bookedDate).ToList();
               // turfs = context.BookingSlots.ToList();
                if (turfs.Any())
                {
                    return View("Index", turfs);

                }
                else
                {
                    return View("Index");
                }
            }

           
            var bookingList = turfs.Select(s => new { s.FullName, s.UserMobileNo,s.BookingSlotFrom,s.BookingSlotTo }).ToList();
            //lstRequiredTurfDetails= lstTurfDetails.Where(x=>x.AvailableFrom)
            if (bookingList.Count>0)
            {
                return View("Index", bookingList);

            }
            else
            {
                return View("Index");
            }
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
