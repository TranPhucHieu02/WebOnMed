using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebBookingCare.Models.ViewModels
{
    public class DuLieuTongQuan
    {
        public string trangThai { get; set; }
        public int soLuong { get; set; }
        public DuLieuTongQuan(string trangthai, int soLuong)
        {
            this.trangThai = trangthai;
            this.soLuong = soLuong;
        }

      

    }
}