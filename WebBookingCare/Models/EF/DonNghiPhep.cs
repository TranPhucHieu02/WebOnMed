using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebBookingCare.Models.EF
{
    [Table("DonNghiPhep")]
    public class DonNghiPhep
    {
        public DonNghiPhep()
        {
            CaNghi = new HashSet<CaNghi>();

        }
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Vui lòng nhập ngày nghỉ!")]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày nghỉ")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgayNghi { get; set; }

        [Display(Name = "Trạng thái")]
        public bool TrangThai { get; set; } = false;

        [Display(Name = "Bác sĩ")]
        public string MaBS { get; set; }

        public virtual BacSi BacSi { get; set; }

        public virtual ICollection<CaNghi> CaNghi { get; set; }
    }
}
