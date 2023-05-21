using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBookingCare.Models;
using WebBookingCare.Models.EF;

namespace WebBookingCare.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CaKhamController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin/CaKham
        public ActionResult DanhSach()
        {
            return View(db.caKham.ToList());
        }

        // GET: Admin/CaKham/Details/5
        public ActionResult ChiTiet(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaKham caKham = db.caKham.Find(id);
            if (caKham == null)
            {
                return HttpNotFound();
            }
            return View(caKham);
        }

        // GET: Admin/CaKham/Create
        public ActionResult ThemCaKham()
        {
            return View();
        }

        // POST: Admin/CaKham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemCaKham(CaKham caKham)
        {
            if (ModelState.IsValid)
            {
                int dsca= db.caKham.Count();
                var ck = new CaKham();
                ck.MaCa = "C" + dsca;
                ck.TenCa = caKham.TenCa;
                ck.ThoiGianBD = caKham.ThoiGianBD;
                ck.ThoiGianKT = caKham.ThoiGianKT;
                ck.SoLuongKham = caKham.SoLuongKham;
                db.caKham.Add(ck);
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }

            return View(caKham);
        }

        // GET: Admin/CaKham/Edit/5
        public ActionResult SuaCaKham(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaKham caKham = db.caKham.Find(id);
            if (caKham == null)
            {
                return HttpNotFound();
            }
            return View(caKham);
        }

        // POST: Admin/CaKham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaCaKham([Bind(Include = "MaCa,TenCa,ThoiGianBD,ThoiGianKT,SoLuongKham")] CaKham caKham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(caKham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhSach");
            }
            return View(caKham);
        }

        // GET: Admin/CaKham/Delete/5
        public ActionResult XoaCaKham(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CaKham caKham = db.caKham.Find(id);
            db.caKham.Remove(caKham);
            db.SaveChanges();
            return RedirectToAction("DanhSach");
        }
      
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
