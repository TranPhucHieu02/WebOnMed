using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebBookingCare.Models.EF
{
    [Table("CaKham")]
    public partial class CaKham
    {
        public CaKham()
        {
            PhieuDatLich = new HashSet<PhieuDatLich>();
            CaNghi = new HashSet<CaNghi>();
        }

        [Key]
        [StringLength(50)]
        public string MaCa { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên Ca")]
        public string TenCa { get; set; }

        [Display(Name = "Trạng thái")]
        public bool TrangThai { get; set; } = true;

        [Display(Name = "Thời Gian Bắt Đầu")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan? ThoiGianBD { get; set; }

        [Display(Name = "Thời Gian Kết thúc")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan? ThoiGianKT { get; set; }
        [Display(Name = "Số Lượng Tối Đa")]
        public int? SoLuongKham { get; set; }

        public virtual ICollection<PhieuDatLich> PhieuDatLich { get; set; }
        public virtual ICollection<CaNghi> CaNghi { get; set; }
    }
}