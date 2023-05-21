using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookingCare.Models;
using WebBookingCare.Models.EF;

namespace WebBookingCare.Areas.Doctor.Controllers
{
    [Authorize(Roles = "BacSi")]
    public class DonNghiPhepController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Doctor/DonNghiPhep
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DangKyNghiPhep(string id) 
        {
            if(id == null)
            {
                return RedirectToAction("danhsach", "phieudatlich");
            }
            var endDay = DateTime.Now.AddDays(12);
            var lichNghi = db.DonNghiPhep.Where(x => x.NgayNghi > DateTime.Now && x.NgayNghi < endDay && x.TrangThai==true && x.MaBS==id).ToList();
            List<DateTime> daDangKyNghi = new List<DateTime>();

            foreach ( var ngayNghi in lichNghi )
            {
                daDangKyNghi.Add(ngayNghi.NgayNghi);
            }
            ViewBag.CaKhamList = db.caKham.ToList();
            ViewBag.BacSi = db.BacSi.SingleOrDefault(x => x.MaBS == id);
            ViewBag.DaDangKyNghi = daDangKyNghi;
            return View();
        }
        [HttpPost]
        public ActionResult DangKyNghiPhep(DonNghiPhep donNghiPhep)
        {
            
            return RedirectToAction("");
        }
    }
}