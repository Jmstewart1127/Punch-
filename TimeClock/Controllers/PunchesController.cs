using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace TimeClock.Models
{
    public class PunchesController : Controller
    {
        private PunchDBContext db = new PunchDBContext();

        public DateTime getTime()
        {
            return DateTime.Now;
        }

        public bool ClockIn(Punch ClockInTime)
        {

            Punch p = new Punch()
            {
                ClockInTime = getTime()
            };

            db.Punch.Add(ClockInTime);
            db.SaveChanges();

            return true;

        }

        // GET: Punches
        public ActionResult Index()
        {
            return View(db.Punch.ToList());
        }

        // GET: Punches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Punch punch = db.Punch.Find(id);
            if (punch == null)
            {
                return HttpNotFound();
            }
            return View(punch);
        }

        // GET: Punches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Punches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserName,ClockInTime,ClockOutTime,TotalTime,TotalPayPeriodTime")] Punch punch)
        {
            if (ModelState.IsValid)
            {
                db.Punch.Add(punch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(punch);
        }

        // GET: Punches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Punch punch = db.Punch.Find(id);
            if (punch == null)
            {
                return HttpNotFound();
            }
            return View(punch);
        }

        // POST: Punches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserName,ClockInTime,ClockOutTime,TotalTime,TotalPayPeriodTime")] Punch punch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(punch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(punch);
        }

        // GET: Punches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Punch punch = db.Punch.Find(id);
            if (punch == null)
            {
                return HttpNotFound();
            }
            return View(punch);
        }

        // POST: Punches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Punch punch = db.Punch.Find(id);
            db.Punch.Remove(punch);
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
