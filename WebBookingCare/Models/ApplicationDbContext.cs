using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebBookingCare.Models.EF;

namespace WebBookingCare.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Admin> Admin { get; set; }
        public DbSet<BacSi> BacSi { get; set; }
        public DbSet<DonNghiPhep> DonNghiPhep { get; set; }
        public DbSet<BenhNhan> BenhNhan { get; set; }
        public DbSet<CaKham> caKham { get; set; }
        public DbSet<CaNghi> CaNghi { get; set; }
        public DbSet<ChucVu> ChucVu { get; set; }
        public DbSet<DanhGia> DanhGia { get; set; }
        public DbSet<DichVu> DichVu { get; set; }
        public DbSet<HoSoBenhAn> HoSoBenhAn { get; set; }
        public DbSet<Khoa> Khoa { get; set; }
        public DbSet<PhieuDatLich> PhieuDatLich { get; set; }
        public DbSet<LienHe> LienHe { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}