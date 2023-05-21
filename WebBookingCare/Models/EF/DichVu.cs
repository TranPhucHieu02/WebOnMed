using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebBookingCare.Models.EF
{
    [Table("DichVu")]
    public partial class DichVu
    {

        [Key]
        [StringLength(50)]
        [Required]
        [Display(Name = "Mã dịch vụ")]
        public string MaDV { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Tên dịch vụ")]
        public string TenDV { get; set; }

        [Required]
        [Display(Name = "Giá dịch vụ")]
        public int? GiaDV { get; set; }

        [StringLength(500)]
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "Hình ảnh")]
        public string HinhAnh { get; set; }

        [StringLength(50)]
        public string MaKhoa { get; set; }

        public virtual Khoa Khoa { get; set; }
    }
}