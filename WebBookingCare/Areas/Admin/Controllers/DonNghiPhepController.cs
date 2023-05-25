using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookingCare.Models;

namespace WebBookingCare.Areas.Admin.Controllers
{
    public class DonNghiPhepController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/DonNghiPhep
        public ActionResult DanhSach()
        {
            var donNghiPhep = db.DonNghiPhep.Where(p=>p.TrangThai == false).ToList();
            return View(donNghiPhep);
        }
    }
}