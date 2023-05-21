using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace WebBookingCare.Models.EF
{
    [Table("PhieuDatLich")]
    public partial class PhieuDatLich
    {
        public PhieuDatLich()
        {
            HoSoBenhAn = new HashSet<HoSoBenhAn>();
        }
        [Key]
        [StringLength(50)]
        [Display(Name = "Mã phiếu đặt lịch")]
        public string MaPDL { get; set; }

        [Display(Name = "Mã bệnh nhân")]
        public string MaBN { get; set; }

        [Display(Name = "Tên bệnh nhân")]
        public string TenBN { get; set; }

        [Display(Name = "Email bệnh nhân")]
        public string Email { get; set; }

        [Display(Name = "SDT bệnh nhân")]
        public string SDT { get; set; }

        [StringLength(500)]
        [Display(Name = "Tình trạng")]
        public string TinhTrang { get; set; }

        [StringLength(10)]
        [Display(Name = "Mã bác sĩ")]
        public string MaBS { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày đặt")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgayDat { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Ngày khám")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime NgayKham { get; set; }

        [StringLength(50)]
        public string MaCa { get; set; }

        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; }

        public virtual BenhNhan BenhNhan { get; set; }

        public virtual CaKham CaKham { get; set; }

        public virtual BacSi BacSi { get; set; }

        public virtual ICollection<HoSoBenhAn> HoSoBenhAn { get; set; }


    }
}