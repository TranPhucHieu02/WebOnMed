using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBookingCare.Models;
using WebBookingCare.Models.EF;
using System.Web.WebPages;

namespace WebBookingCare.Controllers
{

    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index( string MaKhoa)
        {
            return View();
        }
        public ActionResult DatLich()
        {
            ViewBag.Khoa = db.Khoa.ToList();
            ViewBag.CaKham = db.caKham.ToList();
            return View("DatLich");
        }
        [HttpPost]
        public JsonResult DatLich(PhieuDatLich pdl)
        {
            
            try {
                var mapdl = db.PhieuDatLich.Count();
                PhieuDatLich phieuDatLich = new PhieuDatLich();
                phieuDatLich.MaPDL = "PDL" + mapdl;
                //phieuDatLich.MaBN = "BN" + mapdl;
                phieuDatLich.NgayDat = DateTime.Now;
                phieuDatLich.MaBS = pdl.MaBS;
                phieuDatLich.NgayKham = pdl.NgayKham;
                phieuDatLich.TrangThai = 0;
                phieuDatLich.MaCa = pdl.MaCa;
                phieuDatLich.TenBN = pdl.TenBN;
                phieuDatLich.Email = pdl.Email;
                phieuDatLich.SDT = pdl.SDT;
                phieuDatLich.TinhTrang = pdl.TinhTrang;

                db.PhieuDatLich.Add(phieuDatLich);
                db.SaveChanges();

                return Json(new { code = 200, msg = "Đơn đăng ký đã được gửi thành công.!" });
            }
            catch (Exception) {
                return Json(new { code = 500, msg = "Lỗi hệ thông.!" });
            }
        }
        public ActionResult LichKham() 
        {
            var lichKham= db.PhieuDatLich.ToList();
            return View(lichKham);
        }
        public ActionResult TraCuu()
        {
            return View();

        }
        public PartialViewResult _TraCuu(string key)
        {
            var lichKham = db.PhieuDatLich.Where(p => p.Email == key || p.SDT == key).ToList();

            if (key.IsEmpty()|| lichKham.Count()==0)
            {
                return PartialView("_TraCuuNull");
            }
            return PartialView("_TraCuu", lichKham);
        }
        public ActionResult LienHe()
        {
            return View();
        }
        [HttpPost]
        public ActionResult LienHe(LienHe lienHe)
        {
            var lh = new LienHe();
            lh.HoTen = lienHe.HoTen;
            lh.Email = lienHe.Email;
            lh.SDT = lienHe.SDT;
            lh.ChuDe = lienHe.ChuDe;
            lh.NoiDung = lienHe.NoiDung;
            db.LienHe.Add(lh);
            db.SaveChanges();
            return View();
        }
        public ActionResult HoSoKhamBenh(string MaPDL)
        {
            var lichKham = db.PhieuDatLich.SingleOrDefault(p => p.MaPDL == MaPDL);
            return View(lichKham);
        }
        public ActionResult BenhAn(string id)
        {
            var benhAn = db.HoSoBenhAn.SingleOrDefault(p => p.MaPDL == id);
            return View(benhAn);
        }
        public ActionResult GioiThieu()
        {
            return View("GioiThieu");
        }
        public ActionResult QuyTrinh()
        {
            return View("QuyTrinh");
        }
        public JsonResult GetBacSi(string MaKhoa)
        {
            var lsbs = db.BacSi.Where(p=>p.MaKhoa == MaKhoa && p.User.DeleteUser==false).ToList();
            var result = lsbs.Select(x => new {
                x.MaBS,
                x.HoTen,
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDichVu(string MaKhoa)
        {
            var lsdv = db.DichVu.Where(p => p.MaKhoa == MaKhoa).ToList();
            var result = lsdv.Select(x => new {
                x.MaDV,
                x.TenDV,
            });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Khoa()
        {
            return View("Khoa", db.Khoa.ToList());
        }
        public ActionResult BacSi()
        {
            ViewBag.Khoa = db.Khoa.ToList();
            ViewBag.ChucVu = db.ChucVu.ToList();
            var bs = db.BacSi.Where(p=>p.User.DeleteUser == false).ToList();
            return View("BacSi",bs);
        }
        public ActionResult DichVu()
        {
            return View("DichVu", db.DichVu.ToList());
        }
        public PartialViewResult _ThongKe()
        {
            ViewBag.DichVu = db.DichVu.Count();
            ViewBag.BacSi = db.BacSi.Count();
            ViewBag.Khoa = db.Khoa.Count();
            ViewBag.CaKham = db.caKham.Count();
            return PartialView("_ThongKe");
        }

        //public ActionResult _DanhGia()
        //{
        //    return View("_DanhGia");
        //}
        //public  JsonResult SendMail()
        //{
        //    Email email = new Email();
        //    email.Send("Phuchieu2001@gmail.com", "XÁC NHẬN ĐĂNG KÝ THÀNH CÔNG!", "Xin chào\n Cảm ơn bạn đã tin tưởng dịch vụ chăm sóc sức khoẻ OnMed.\nĐơn đăng ký của bạn đã được duyệt.\n\n\tMã số: " );
        //    return Json(new { code = 200, msg = "Đăng ký thành công" }, JsonRequestBehavior.AllowGet);

        //}
        //public class Email
        //{
        //    public static string Address = "phuchieu1213@gmail.com"; //Địa chỉ email của bạn
        //    public static string Password = "nxpthpviosnyutmh"; //Mật khẩu ứng dụng

        //    public void Send(string sendTo, string subject, string message)
        //    {
        //        using (SmtpClient smtp = new SmtpClient())
        //        {
        //            smtp.Host = "smtp.gmail.com";
        //            smtp.Port = 587;
        //            smtp.EnableSsl = true;
        //            smtp.Credentials = new NetworkCredential(Address, Password);
        //            smtp.Send(Address, sendTo, subject, message);
        //        }
        //    }
        //}

    }
}