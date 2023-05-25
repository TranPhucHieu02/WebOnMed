using Microsoft.AspNet.Identity.Owin;
using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebBookingCare.Models;
using WebBookingCare.Models.EF;
using WebBookingCare.Models.ViewModels;

namespace WebBookingCare.Areas.Admin.Controllers
{
    [Authorize(Roles ="Admin")]
    public class BacSiController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationUserManager userManager;
        private ApplicationSignInManager signInManager;

        public BacSiController()
        {
        }

        public BacSiController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                userManager = value;
            }
        }

        // GET: Admin/BacSi
        public ActionResult DanhSach()
        {

            return View(db.BacSi.Where(p=>p.User.DeleteUser==false).ToList());
        }

        public ActionResult ThemBacSi()
        {
            ViewBag.MaCV = new SelectList(db.ChucVu, "MaCV", "TenCV");
            ViewBag.MaKhoa = new SelectList(db.Khoa, "MaKhoa", "TenKhoa");
            ViewBag.MaDV = new SelectList(db.DichVu, "MaDV", "TenDV");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ThemBacSi(BacSiViewmodel bacSi)
        {
            if (ModelState.IsValid)
            {
                string Id = "User" + db.Users.Count();
                var user = new ApplicationUser { UserName = bacSi.Email, Email = bacSi.Email, Id = Id };
                var result = await UserManager.CreateAsync(user, "Bacsi123@onmed.com");
                if (result.Succeeded)
                {
                    var bs = new  BacSi();
                    var mabs = Id;
                    bs.MaBS = mabs;
                    bs.HoTen = bacSi.HoTen;
                    bs.GioiTinh = bacSi.GioiTinh;
                    bs.Sdt = bacSi.SDT;
                    bs.Avt = bacSi.Avt;
                    bs.NgaySinh = bacSi.NgaySinh;
                    bs.MaKhoa = bacSi.MaKhoa;
                    bs.MaCV = bacSi.MaCV;
                    db.BacSi.Add(bs);
                    db.SaveChanges();
                    await UserManager.AddToRoleAsync(Id, "BacSi");

                    return RedirectToAction("Index", "Home", new { area = "Admin" });

                }
                ViewBag.MaCV = new SelectList(db.ChucVu, "MaCV", "TenCV", bacSi.MaCV);
                ViewBag.MaKhoa = new SelectList(db.Khoa, "MaKhoa", "TenKhoa", bacSi.MaKhoa);
                ViewBag.Email = "Da ton tai";
                return View(bacSi);
            }

            ViewBag.MaCV = new SelectList(db.ChucVu, "MaCV", "TenCV", bacSi.MaCV);
            ViewBag.MaKhoa = new SelectList(db.Khoa, "MaKhoa", "TenKhoa", bacSi.MaKhoa);
            return View(bacSi);
        }

        public ActionResult ThongTinBS(string MaBS)
        {
            var bs = db.BacSi.SingleOrDefault(P => P.MaBS == MaBS);
            return View(bs);
        }

        public ActionResult SuaBacSi(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BacSi bacSi = db.BacSi.Find(id);
            if (bacSi == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCV = new SelectList(db.ChucVu, "MaCV", "TenCV", bacSi.MaCV);
            ViewBag.MaKhoa = new SelectList(db.Khoa, "MaKhoa", "TenKhoa", bacSi.MaKhoa);
            return View(bacSi);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaBacSi( BacSi bacSi)
        {
            
            if (ModelState.IsValid)
            {
                var bs = new BacSi();
                bs.MaBS = bacSi.MaBS;
                bs.HoTen = bacSi.HoTen;
                bs.MaKhoa = bacSi.MaKhoa;
                bs.NgaySinh = bacSi.NgaySinh;
                bs.Avt = bacSi.Avt;
                bs.GioiTinh = bacSi.GioiTinh;
                bs.MaCV = bacSi.MaCV;
                bs.Sdt = bacSi.Sdt;
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            return View(bacSi);
        }

        public ActionResult XoaBacSi(string id)
        {
            var bacSi = db.BacSi.SingleOrDefault(p=>p.MaBS == id);
            bacSi.User.DeleteUser = true;
            bacSi.User.LockoutEnabled = true;
            bacSi.User.LockoutEndDateUtc = DateTime.Now.AddYears(1000);
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/assets/admin/img/doctors" + file.FileName));
            return "/assets/admin/img/doctors" + file.FileName;
        }
    }
}
