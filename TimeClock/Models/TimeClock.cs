using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TimeClock.Models
{
    public class TimeClock
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public DateTime ClockInTime { get; set; }
        public DateTime ClockOutTime { get; set; }
        public DateTime TotalTime { get; set; }
        public DateTime TotalPayPeriodTime { get; set; }
    }

    public class TimeClockDBContext : DbContext
    {
        public DbSet<TimeClock> TimeClock { get; set; }
    }
}