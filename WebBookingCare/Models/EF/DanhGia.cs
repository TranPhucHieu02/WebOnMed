using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBookingCare.Models.EF
{
    [Table("DanhGia")]
    public partial class DanhGia
    {
        [Key]
        [StringLength(50)]
        [Display(Name ="Mã đánh giá")]
        public string MaDanhGia { get; set; }

        [StringLength (500,ErrorMessage ="Đánh giá không vượt quá 500 ký tự")]
        [Display(Name = "Nội dung")]
        public string NoiDung { get; set; }

        [Required(ErrorMessage ="vui lòng chọn mức đánh giá")]
        [Display(Name = "Mức đánh giá")]
        public double MucDanhGia { get;set; }

        public DateTime NgayDanhGia { get; set; }=DateTime.Now;

        [Display(Name = "Mã bệnh nhân")]
        public string MaBN { get; set; }

        [Display(Name = "Mã bác sĩ")]
        public string MaBS { get; set; }

        public virtual BacSi BacSi { get; set; }

        public virtual BenhNhan BenhNhan { get; set; }
    }
}