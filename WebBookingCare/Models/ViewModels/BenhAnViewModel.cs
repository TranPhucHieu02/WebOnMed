using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebBookingCare.Models.EF;

namespace WebBookingCare.Models.ViewModels
{
    public class BenhAnViewModel
    {
        public PhieuDatLich PhieuDatLich { get; set; }
        public HoSoBenhAn HoSoBenhAn { get; set; }
    }
}