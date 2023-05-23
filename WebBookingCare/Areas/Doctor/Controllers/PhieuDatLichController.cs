using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookingCare.Models;
using WebBookingCare.Models.EF;
using WebBookingCare.Models.ViewModels;

namespace WebBookingCare.Areas.Doctor.Controllers
{
    [Authorize(Roles = "BacSi")]
    public class PhieuDatLichController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Doctor/PhieuDatLich
        public ActionResult DanhSach()
        {
            string id = User.Identity.GetUserId();
            var nowdate = DateTime.Now;
            var ls = db.PhieuDatLich.Where(p=>p.MaBS==id && p.TrangThai==1 && p.NgayKham == nowdate.Date).OrderBy(p => p.MaCa).ToList();
            return View(ls);
        }
        public ActionResult DuyetLich()
        {
            var nowdate = DateTime.Now.Date;
            string id = User.Identity.GetUserId();
            var ls = db.PhieuDatLich.Where(p => p.MaBS == id && p.TrangThai == 0 &&p.NgayKham >= nowdate ).OrderBy(p => p.NgayKham).ToList();
            return View(ls);
        }
        [HttpPost]
        public JsonResult DuyetLich(string maPDL,string status)
        {
            var pdl = db.PhieuDatLich.SingleOrDefault(p => p.MaPDL == maPDL);
            if (status == "add")
            {
                pdl.TrangThai = 1;

            }
            else
            {
                pdl.TrangThai = 3;
            }
            db.SaveChanges();
            return Json(new { success = true });
        }

        public ActionResult ChiTietKhamBenh(string id)
        {
            var pdl = db.PhieuDatLich.SingleOrDefault(p=>p.MaPDL==id);
            BenhAnViewModel benhAn = new BenhAnViewModel();
            benhAn.PhieuDatLich = new PhieuDatLich();
            benhAn.HoSoBenhAn = new HoSoBenhAn();
            benhAn.PhieuDatLich = pdl;
            return View(benhAn);
        }
        [HttpPost]
        public ActionResult ChiTietKhamBenh(BenhAnViewModel benhAn)
        {
            if (!ModelState.IsValid)
            {

                return View(benhAn);
            }
            var pdl = db.PhieuDatLich.Find(benhAn.PhieuDatLich.MaPDL);
            pdl.TrangThai = 2;
            var hsba = new HoSoBenhAn();
            var count = db.HoSoBenhAn.Count();
            hsba.MaHS = "HS"+count ;
            hsba.MaPDL = benhAn.PhieuDatLich.MaPDL;
            hsba.TenBenh = benhAn.HoSoBenhAn.TenBenh;
            hsba.TenThuoc = benhAn.HoSoBenhAn.TenThuoc;
            hsba.CachDieuTri = benhAn.HoSoBenhAn.CachDieuTri;
            hsba.LuuY = benhAn.HoSoBenhAn.LuuY;

            db.HoSoBenhAn.Add(hsba);
            db.SaveChanges();
            
            return RedirectToAction("DanhSach");
        }
    }
}