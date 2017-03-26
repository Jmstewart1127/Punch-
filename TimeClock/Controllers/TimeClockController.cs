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
