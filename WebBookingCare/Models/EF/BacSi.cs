using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBookingCare.Models.EF
{
    [Table("BacSi")]
    public class BacSi
    {
        public BacSi()
        {
            DanhGia = new HashSet<DanhGia>();
            DonNghiPhep = new HashSet<DonNghiPhep>();
        }
        [Key, ForeignKey("User")]
        public string MaBS { get; set; }

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

        [StringLength(50)]
        public string MaKhoa { get; set; }

        [StringLength(50)]
        public string MaCV { get; set; }

        public virtual ChucVu ChucVu { get; set; }
        public virtual Khoa Khoa { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<DanhGia> DanhGia { get; set; }
        public virtual ICollection<DonNghiPhep> DonNghiPhep { get; set; }
    }
}