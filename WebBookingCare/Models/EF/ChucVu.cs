using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace WebBookingCare.Models.EF
{
    [Table("ChucVu")]
    public partial class ChucVu
    {
        public ChucVu()
        {
            BacSi = new HashSet<BacSi>();
        }

        [Key]
        [StringLength(50)]
        [Display(Name ="Mã chức vụ")]
        public string MaCV { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên chức vụ")]
        public string TenCV { get; set; }

        public virtual ICollection<BacSi> BacSi { get; set; }
    }
}