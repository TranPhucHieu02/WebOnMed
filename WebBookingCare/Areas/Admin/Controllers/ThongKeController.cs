using System;
using System.Collections.Generic;
using System.Linq;
using ClosedXML.Excel;
using System.Web;
using System.Web.Mvc;
using WebBookingCare.Models;
using WebBookingCare.Models.EF;

namespace WebBookingCare.Areas.Admin.Controllers
{
    public class ThongKeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ThongKe
        public ActionResult DanhSach()
        {
            return View(db.PhieuDatLich.ToList());
        }
        public PartialViewResult _DanhSach(int? id)
        {
            var lsPDL = new List<PhieuDatLich>();
            if(id == null)
            {
                lsPDL = db.PhieuDatLich.ToList();
            }
            else
            {
                lsPDL = db.PhieuDatLich.Where(p => p.TrangThai == id).ToList();

            }
            return PartialView(lsPDL);
        }

        [HttpPost]
        public JsonResult XuatExcel(string id)
        {
            try
            {
                var pdl = new List<PhieuDatLich>();
                switch (id)
                {
                    case "":
                        pdl = db.PhieuDatLich.ToList();
                        break;
                    case "0":
                        pdl = db.PhieuDatLich.Where(p => p.TrangThai == 0).ToList();

                        break;
                    case "1":
                        pdl = db.PhieuDatLich.Where(p => p.TrangThai == 1).ToList();

                        break;
                    case "2":
                        pdl = db.PhieuDatLich.Where(p => p.TrangThai == 2).ToList();

                        break;
                    case "3":
                        pdl = db.PhieuDatLich.Where(p => p.TrangThai == 3).ToList();

                        break;

                }


                var wb = new XLWorkbook();
                var ws = wb.AddWorksheet("PhieuDatLich");
                ws.Cell("A1").Value = "Mã Phiếu";
                ws.Cell("B1").Value = "Họ Tên";
                ws.Cell("C1").Value = "Email";
                ws.Cell("D1").Value = "SDT";
                ws.Cell("E1").Value = "Khoa";
                ws.Cell("F1").Value = "Bác Sĩ";
                ws.Cell("G1").Value = "Ngày Khám";
                ws.Cell("H1").Value = "Ca Khám";
                ws.Cell("I1").Value = "Trạng Thái";
                int row = 2;
                for (int i = 0; i < pdl.Count(); i++)
                {
                    ws.Cell("A" + row).Value = pdl[i].MaPDL;
                    ws.Cell("B" + row).Value = pdl[i].TenBN;
                    ws.Cell("C" + row).Value = pdl[i].Email;
                    ws.Cell("D" + row).Value = pdl[i].SDT;
                    ws.Cell("E" + row).Value = pdl[i].BacSi.Khoa.TenKhoa;
                    ws.Cell("F" + row).Value = pdl[i].BacSi.HoTen;
                    ws.Cell("G" + row).Value = pdl[i].NgayKham.Date;
                    ws.Cell("H" + row).Value = pdl[i].CaKham.TenCa;
                    switch (pdl[i].TrangThai)
                    {
                        case 0:
                            ws.Cell("I" + row).Value = "Chưa duyệt";
                            break;
                        case 1:
                            ws.Cell("I" + row).Value = "Đã duyệt";
                            break;
                        case 2:
                            ws.Cell("I" + row).Value = "Đã Khám";
                            break;
                        case 3:
                            ws.Cell("I" + row).Value = "Đã Hủy";
                            break;

                    }
                    row++;
                }
                string filename = "Export_" + DateTime.Now.Ticks + ".xlsx";
                string pathFile = Server.MapPath("~/Content/FileExcel/" + filename);

                wb.SaveAs(pathFile);
                return Json(new { code = 200, msg = filename }, JsonRequestBehavior.AllowGet);
            }
            catch { return Json(new { code = 500, msg = "Lỗi  trong quá trình thực thi" }, JsonRequestBehavior.AllowGet); }

        }
    }
}