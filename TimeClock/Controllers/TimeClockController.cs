using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TimeClock.Controllers
{
    public class TimeClockController : Controller
    {

        private DateTime startTime;

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