using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebBookingCare.Models.EF
{
    [Table("Admin")]
    public class Admin
    {
        [Key, ForeignKey("User")]
        public string MaAD { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập họ tên !")]
        [StringLength(250, ErrorMessage = "vượt quá độ dài cho phép")]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày sinh!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Ngày sinh")]
        public string NgaySinh { get; set; }

        [Required(ErrorMessage = "Vui lòng chọn giới tính!")]
        [Display(Name = "Giới tính")]
        public bool GioiTinh { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập số điện thoại!")]
        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [StringLength(15, ErrorMessage = "vượt quá độ dài cho phép")]
        [Display(Name = "Số điện thoại")]
        public string Sdt { get; set; }

        [StringLength(250)]
        [Display(Name = "Hình ảnh")]
        public string Avt { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}