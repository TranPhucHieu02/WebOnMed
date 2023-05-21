using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebBookingCare.Models.EF
{
    [Table("CaNghi")]
    public class CaNghi
    {
        [Key]
        public int Id { get; set; }

        public int DonNghiPhepId { get; set; }

        public string MaCa { get; set; }

        public virtual DonNghiPhep DonNghiPhep { get; set; }

        public virtual CaKham CaKham { get; set; }
    }
}