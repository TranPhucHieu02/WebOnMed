using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebBookingCare.Models.ViewModels
{
    public class BacSiViewmodel
    {
        [Required]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày sinh!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày sinh")]
        public string NgaySinh { get; set; }

        [Required]
        [Display(Name = "Giới tính")]
        public bool GioiTinh { get; set; }

        [Required]
        [Display(Name = "SDT")]
        public string SDT { get; set; }

        [Display(Name = "Avt")]
        public string Avt { get; set; }

        [Required]
        [Display(Name = "Ma Khoa")]
        public string MaKhoa { get; set; }

        [Required]
        [Display(Name = "Ma CV")]
        public string MaCV { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}