using WebBookingCare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookingCare.Models.EF;
using WebBookingCare.Models.ViewModels;

namespace WebBookingCare.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Home
        public ActionResult Index() {
            List<PhieuDatLich> lslk = new List<PhieuDatLich>() ;
            lslk = db.PhieuDatLich.Where(p => p.NgayKham.Year == DateTime.Now.Year).ToList();
            ViewBag.PhieuDatlich = db.PhieuDatLich.Count();
            ViewBag.DichVu = db.DichVu.Count();
            ViewBag.User= db.caKham.Count(); 
            ViewBag.BacSi = db.BacSi.Count();
            var data = new List<DuLieuTongQuan>();
            string trangThai;
            for (int i = 0; i< 4; i++)
            {
                
                var soluong = lslk.Where(x => x.TrangThai==i).ToList().Count();
                if (i == 0)
                {
                    trangThai = "Chưa Duyệt";
                    data.Add(new DuLieuTongQuan(trangThai, soluong));
                }
                else if (i == 1)
                {
                    data.Add(new DuLieuTongQuan("Đã Duyệt", soluong));

                }
                else if (i == 2)
                {
                    data.Add(new DuLieuTongQuan("Đã Khám", soluong));

                }
                else if (i == 3)
                {
                    data.Add(new DuLieuTongQuan("Đã Hủy", soluong));
                }
            }
            ViewBag.Data = data;
            return View();
        }
        public ActionResult LienHe()
        {
            var lsLienHe = db.LienHe.ToList();
            return View(lsLienHe);
        }
        public ActionResult ChiTietLienHe(int id)
        {
            if (id == null)
            {
                RedirectToAction("lienhe");
            }
            var lh = db.LienHe.SingleOrDefault(p => p.MaLH == id);
            return View(lh);
        }

    }
}