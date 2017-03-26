using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TimeClock.Models;



    public class TimeClockController : Controller
    {

        private TimeClockDBContext db = new TimeClockDBContext();
        private DateTime startTime;

        // GET: TimeClocks
        public ActionResult Index()
        {
            return View(db.TimeClock.ToList());
        }

        // GET: TimeClocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeClock timeClock = db.TimeClock.Find(id);
            if (timeClock == null)
            {
                return HttpNotFound();
            }
            return View(timeClock);
        }

        // GET: TimeClocks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TimeClocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,ClockInTime,ClockOutTime,TotalTime,TotalPayPeriodTime")] timeClock)
        {
            if (ModelState.IsValid)
            {
                db.TimeClock.Add(timeClock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timeClock);
        }

        // GET: TimeClocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeClock timeClock = db.TimeClock.Find(id);
            if (timeClock == null)
            {
                return HttpNotFound();
            }
            return View(timeClock);
        }

        // POST: TimeClocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,ClockInTime,ClockOutTime,TotalTime,TotalPayPeriodTime")] TimeClock timeClock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeClock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timeClock);
        }

        // GET: TimeClocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeClock timeClock = db.TimeClock.Find(id);
            if (timeClock == null)
            {
                return HttpNotFound();
            }
            return View(timeClock);
        }

        // POST: TimeClocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeClock timeClock = db.TimeClock.Find(id);
            db.TimeClock.Remove(timeClock);
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

        // GET: TimeClock
        public ActionResult ClockIn()
        {
            ViewBag.message = "hello World";

            return View();
        }

        public ActionResult Punch()
        {
            return View();
        }

        public DateTime getCurrentTime()
        {
            startTime = DateTime.Now;

            return startTime;
        }
    
    }
}