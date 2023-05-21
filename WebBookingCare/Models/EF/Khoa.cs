using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBookingCare.Models.EF
{
    [Table("Khoa")]
    public partial class Khoa
    {
        public Khoa()
        {
            BacSi = new HashSet<BacSi>();
            DichVu = new HashSet<DichVu>();
        }

        [Key]
        [StringLength(50)]
        [Display(Name = "Mã khoa")]
        public string MaKhoa { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên khoa")]
        public string TenKhoa { get; set; }

        [StringLength(1000)]
        [Display(Name = "Thông tin khoa")]
        public string ThongTinKhoa { get; set; }

        [StringLength(250)]
        [Display(Name = "Ảnh Khoa")]
        public string AnhKhoa { get; set; }

        public virtual ICollection<BacSi> BacSi { get; set; }
        public virtual ICollection<DichVu> DichVu { get; set; }
    }
}