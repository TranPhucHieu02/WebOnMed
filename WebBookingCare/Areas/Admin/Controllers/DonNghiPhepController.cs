using Microsoft.AspNet.Identity;
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
            var nowdate = DateTime.Now.Date;
            var ls = db.DonNghiPhep.Where(p => p.NgayNghi >= nowdate && p.TrangThai==false).OrderBy(p => p.NgayNghi).ToList();
            return View(ls);
        }

        //public ActionResult DuyetDon()
        //{
        //    var nowdate = DateTime.Now.Date;
        //    var ls = db.DonNghiPhep.Where(p => p.NgayNghi >= nowdate).OrderBy(p => p.NgayNghi).ToList();
        //    return View(ls);
        //}
        [HttpPost]
        public JsonResult DuyetDon(int id, string status)
        {
            var dnp = db.DonNghiPhep.SingleOrDefault(p => p.Id == id);
            if (status == "add")
            {
                dnp.TrangThai = true;

            }
            else
            {
                dnp.TrangThai = false;
            }
            db.SaveChanges();
            return Json(new { success = true });
        }
    }
}