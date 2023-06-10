using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBookingCare.Areas.Doctor.Controllers
{
    public class HomeController : Controller
    {
        // GET: Doctor/Home
        public ActionResult Index()
        {
            DateTime today = DateTime.Today;

            DateTime firstDayOfWeek = today.AddDays(-(int)today.DayOfWeek + 1);

            DateTime lastDayOfWeek = firstDayOfWeek.AddDays(6);
            return View();
        }
    }
}