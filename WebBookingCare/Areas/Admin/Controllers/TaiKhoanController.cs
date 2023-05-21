using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookingCare.Models;

namespace WebBookingCare.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TaiKhoanController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public TaiKhoanController()
        {
        }

        public TaiKhoanController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        // GET: Admin/TaiKhoan
        public ActionResult DanhSach()
        {
            
            
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var lsuser = userManager.Users.Where(p=>p.BacSi.MaBS!=null).ToList();
            ViewBag.User = lsuser;
            return View();
        }
        [HttpPost]
        public ActionResult TrangThai(string userId, string status)
        {
            var userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            if (string.IsNullOrEmpty(userId) || string.IsNullOrEmpty(status))
            {
                return Json(new { success = false, message = "Không tìm thấy thông tin tài khoản." });
            }

            bool deleteState = false;
            if (status == "unlocked")
            {
                deleteState = true;
                
            }

            using (var db = new ApplicationDbContext())
            {
                var user = db.Users.SingleOrDefault(p => p.UserName == userId);
                if (user == null)
                {
                    return Json(new { success = false, message = "Không tìm thấy thông tin tài khoản." });
                }

                user.DeleteUser = deleteState;
                user.LockoutEndDateUtc = DateTime.Now.AddYears(1000);
                user.LockoutEnabled = deleteState;
                db.SaveChanges();
            }

            return Json(new { success = true });
        }


    }
}