namespace WebBookingCare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatebd20 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PhieuDatLich", "MaBS", "dbo.BacSi");
            DropForeignKey("dbo.PhieuDatLich", "MaCa", "dbo.CaKham");
            DropIndex("dbo.PhieuDatLich", new[] { "MaBS" });
            DropIndex("dbo.PhieuDatLich", new[] { "MaCa" });
            AddColumn("dbo.PhieuDatLich", "Tuoi", c => c.Int(nullable: false));
            AlterColumn("dbo.PhieuDatLich", "TenBN", c => c.String(nullable: false));
            AlterColumn("dbo.PhieuDatLich", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.PhieuDatLich", "SDT", c => c.String(nullable: false));
            AlterColumn("dbo.PhieuDatLich", "TinhTrang", c => c.String(nullable: false, maxLength: 500));
            AlterColumn("dbo.PhieuDatLich", "MaBS", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.PhieuDatLich", "NgayDat", c => c.DateTime(nullable: false, storeType: "date"));
            AlterColumn("dbo.PhieuDatLich", "MaCa", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.PhieuDatLich", "MaBS");
            CreateIndex("dbo.PhieuDatLich", "MaCa");
            AddForeignKey("dbo.PhieuDatLich", "MaBS", "dbo.BacSi", "MaBS", cascadeDelete: true);
            AddForeignKey("dbo.PhieuDatLich", "MaCa", "dbo.CaKham", "MaCa", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhieuDatLich", "MaCa", "dbo.CaKham");
            DropForeignKey("dbo.PhieuDatLich", "MaBS", "dbo.BacSi");
            DropIndex("dbo.PhieuDatLich", new[] { "MaCa" });
            DropIndex("dbo.PhieuDatLich", new[] { "MaBS" });
            AlterColumn("dbo.PhieuDatLich", "MaCa", c => c.String(maxLength: 50));
            AlterColumn("dbo.PhieuDatLich", "NgayDat", c => c.DateTime(storeType: "date"));
            AlterColumn("dbo.PhieuDatLich", "MaBS", c => c.String(maxLength: 128));
            AlterColumn("dbo.PhieuDatLich", "TinhTrang", c => c.String(maxLength: 500));
            AlterColumn("dbo.PhieuDatLich", "SDT", c => c.String());
            AlterColumn("dbo.PhieuDatLich", "Email", c => c.String());
            AlterColumn("dbo.PhieuDatLich", "TenBN", c => c.String());
            DropColumn("dbo.PhieuDatLich", "Tuoi");
            CreateIndex("dbo.PhieuDatLich", "MaCa");
            CreateIndex("dbo.PhieuDatLich", "MaBS");
            AddForeignKey("dbo.PhieuDatLich", "MaCa", "dbo.CaKham", "MaCa");
            AddForeignKey("dbo.PhieuDatLich", "MaBS", "dbo.BacSi", "MaBS");
        }
    }
}
