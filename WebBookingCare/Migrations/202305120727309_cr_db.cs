namespace WebBookingCare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cr_db : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admin",
                c => new
                    {
                        MaAD = c.String(nullable: false, maxLength: 128),
                        HoTen = c.String(nullable: false, maxLength: 250),
                        NgaySinh = c.String(nullable: false),
                        GioiTinh = c.Boolean(nullable: false),
                        Sdt = c.String(nullable: false, maxLength: 15),
                        Avt = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.MaAD)
                .ForeignKey("dbo.AspNetUsers", t => t.MaAD)
                .Index(t => t.MaAD);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        DeleteUser = c.Boolean(nullable: false),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.BacSi",
                c => new
                    {
                        MaBS = c.String(nullable: false, maxLength: 128),
                        HoTen = c.String(nullable: false, maxLength: 250),
                        NgaySinh = c.String(nullable: false),
                        GioiTinh = c.Boolean(nullable: false),
                        Sdt = c.String(nullable: false, maxLength: 15),
                        Avt = c.String(maxLength: 250),
                        MaKhoa = c.String(maxLength: 50),
                        MaCV = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaBS)
                .ForeignKey("dbo.ChucVu", t => t.MaCV)
                .ForeignKey("dbo.Khoa", t => t.MaKhoa)
                .ForeignKey("dbo.AspNetUsers", t => t.MaBS)
                .Index(t => t.MaBS)
                .Index(t => t.MaKhoa)
                .Index(t => t.MaCV);
            
            CreateTable(
                "dbo.ChucVu",
                c => new
                    {
                        MaCV = c.String(nullable: false, maxLength: 50),
                        TenCV = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.MaCV);
            
            CreateTable(
                "dbo.DanhGia",
                c => new
                    {
                        MaDanhGia = c.String(nullable: false, maxLength: 50),
                        NoiDung = c.String(maxLength: 500),
                        MucDanhGia = c.Double(nullable: false),
                        NgayDanhGia = c.DateTime(nullable: false),
                        MaBN = c.String(maxLength: 128),
                        MaBS = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.MaDanhGia)
                .ForeignKey("dbo.BacSi", t => t.MaBS)
                .ForeignKey("dbo.BenhNhan", t => t.MaBN)
                .Index(t => t.MaBN)
                .Index(t => t.MaBS);
            
            CreateTable(
                "dbo.BenhNhan",
                c => new
                    {
                        MaBN = c.String(nullable: false, maxLength: 128),
                        HoTen = c.String(nullable: false, maxLength: 250),
                        NgaySinh = c.String(nullable: false),
                        GioiTinh = c.Boolean(nullable: false),
                        Sdt = c.String(nullable: false, maxLength: 15),
                        Avt = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.MaBN)
                .ForeignKey("dbo.AspNetUsers", t => t.MaBN)
                .Index(t => t.MaBN);
            
            CreateTable(
                "dbo.PhieuDatLich",
                c => new
                    {
                        MaPDL = c.String(nullable: false, maxLength: 50),
                        MaBN = c.String(maxLength: 128),
                        TenBN = c.String(),
                        Email = c.String(),
                        SDT = c.String(),
                        TinhTrang = c.String(maxLength: 500),
                        MaBS = c.String(maxLength: 128),
                        NgayDat = c.DateTime(storeType: "date"),
                        NgayKham = c.DateTime(nullable: false, storeType: "date"),
                        MaCa = c.String(maxLength: 50),
                        TrangThai = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MaPDL)
                .ForeignKey("dbo.BacSi", t => t.MaBS)
                .ForeignKey("dbo.BenhNhan", t => t.MaBN)
                .ForeignKey("dbo.CaKham", t => t.MaCa)
                .Index(t => t.MaBN)
                .Index(t => t.MaBS)
                .Index(t => t.MaCa);
            
            CreateTable(
                "dbo.CaKham",
                c => new
                    {
                        MaCa = c.String(nullable: false, maxLength: 50),
                        TenCa = c.String(maxLength: 250),
                        ThoiGianBD = c.Time(precision: 7),
                        ThoiGianKT = c.Time(precision: 7),
                        SoLuongKham = c.Int(),
                    })
                .PrimaryKey(t => t.MaCa);
            
            CreateTable(
                "dbo.HoSoBenhAns",
                c => new
                    {
                        MaHS = c.String(nullable: false, maxLength: 50),
                        TenBenh = c.String(maxLength: 250),
                        TenThuoc = c.String(maxLength: 250),
                        CachDieuTri = c.String(maxLength: 500),
                        LuuY = c.String(maxLength: 500),
                        MaPDL = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaHS)
                .ForeignKey("dbo.PhieuDatLich", t => t.MaPDL)
                .Index(t => t.MaPDL);
            
            CreateTable(
                "dbo.Khoa",
                c => new
                    {
                        MaKhoa = c.String(nullable: false, maxLength: 50),
                        TenKhoa = c.String(maxLength: 250),
                        ThongTinKhoa = c.String(maxLength: 1000),
                        AnhKhoa = c.String(maxLength: 250),
                    })
                .PrimaryKey(t => t.MaKhoa);
            
            CreateTable(
                "dbo.DichVu",
                c => new
                    {
                        MaDV = c.String(nullable: false, maxLength: 50),
                        TenDV = c.String(nullable: false, maxLength: 250),
                        GiaDV = c.Int(nullable: false),
                        MoTa = c.String(maxLength: 500),
                        HinhAnh = c.String(nullable: false, maxLength: 500),
                        MaKhoa = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaDV)
                .ForeignKey("dbo.Khoa", t => t.MaKhoa)
                .Index(t => t.MaKhoa);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Admin", "MaAD", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.BacSi", "MaBS", "dbo.AspNetUsers");
            DropForeignKey("dbo.DichVu", "MaKhoa", "dbo.Khoa");
            DropForeignKey("dbo.BacSi", "MaKhoa", "dbo.Khoa");
            DropForeignKey("dbo.BenhNhan", "MaBN", "dbo.AspNetUsers");
            DropForeignKey("dbo.HoSoBenhAns", "MaPDL", "dbo.PhieuDatLich");
            DropForeignKey("dbo.PhieuDatLich", "MaCa", "dbo.CaKham");
            DropForeignKey("dbo.PhieuDatLich", "MaBN", "dbo.BenhNhan");
            DropForeignKey("dbo.PhieuDatLich", "MaBS", "dbo.BacSi");
            DropForeignKey("dbo.DanhGia", "MaBN", "dbo.BenhNhan");
            DropForeignKey("dbo.DanhGia", "MaBS", "dbo.BacSi");
            DropForeignKey("dbo.BacSi", "MaCV", "dbo.ChucVu");
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.DichVu", new[] { "MaKhoa" });
            DropIndex("dbo.HoSoBenhAns", new[] { "MaPDL" });
            DropIndex("dbo.PhieuDatLich", new[] { "MaCa" });
            DropIndex("dbo.PhieuDatLich", new[] { "MaBS" });
            DropIndex("dbo.PhieuDatLich", new[] { "MaBN" });
            DropIndex("dbo.BenhNhan", new[] { "MaBN" });
            DropIndex("dbo.DanhGia", new[] { "MaBS" });
            DropIndex("dbo.DanhGia", new[] { "MaBN" });
            DropIndex("dbo.BacSi", new[] { "MaCV" });
            DropIndex("dbo.BacSi", new[] { "MaKhoa" });
            DropIndex("dbo.BacSi", new[] { "MaBS" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Admin", new[] { "MaAD" });
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.DichVu");
            DropTable("dbo.Khoa");
            DropTable("dbo.HoSoBenhAns");
            DropTable("dbo.CaKham");
            DropTable("dbo.PhieuDatLich");
            DropTable("dbo.BenhNhan");
            DropTable("dbo.DanhGia");
            DropTable("dbo.ChucVu");
            DropTable("dbo.BacSi");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Admin");
        }
    }
}
