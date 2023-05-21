using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebBookingCare.Models.EF
{
    public class HoSoBenhAn
    {
        [Key]
        [StringLength(50)]
        public string MaHS { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên bệnh")]
        public string TenBenh { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên thuốc")]
        public string TenThuoc { get; set; }

        [StringLength(500)]
        [Display(Name = "Cách điều trị")]
        public string CachDieuTri { get; set; }

        [StringLength(500)]
        [Display(Name = "Lưu ý")]
        public string LuuY { get; set; }

        [StringLength(50)]
        [Display(Name = "Mã phiếu đặt lịch")]
        public string MaPDL { get; set; }

        public virtual PhieuDatLich PhieuDatLich { get; set; }
    }
}