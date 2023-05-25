using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebBookingCare.Models.EF
{
    public class LienHe
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Mã liên hệ")]
        public int MaLH { get; set; }

        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "SDT")]
        public string SDT { get; set; }
        [Display(Name = "Thời gian")]
        public DateTime ThoiGian { get; set; }

        [StringLength(500)]
        [Display(Name = "Chủ đề")]
        public string ChuDe { get; set; }

        [StringLength(500)]
        [Display(Name = "Nội Dung")]
        public string NoiDung { get; set; }
    }
}