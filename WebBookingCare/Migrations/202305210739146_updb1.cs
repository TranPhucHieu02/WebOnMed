namespace WebBookingCare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updb1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DonNghiPhepCaKhams", "DonNghiPhep_Id", "dbo.DonNghiPhep");
            DropForeignKey("dbo.DonNghiPhepCaKhams", "CaKham_MaCa", "dbo.CaKham");
            DropIndex("dbo.DonNghiPhepCaKhams", new[] { "DonNghiPhep_Id" });
            DropIndex("dbo.DonNghiPhepCaKhams", new[] { "CaKham_MaCa" });
            CreateTable(
                "dbo.CaNghi",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DonNghiPhepId = c.Int(nullable: false),
                        MaCa = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CaKham", t => t.MaCa)
                .ForeignKey("dbo.DonNghiPhep", t => t.DonNghiPhepId, cascadeDelete: true)
                .Index(t => t.DonNghiPhepId)
                .Index(t => t.MaCa);
            
            DropTable("dbo.DonNghiPhepCaKhams");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.DonNghiPhepCaKhams",
                c => new
                    {
                        DonNghiPhep_Id = c.Int(nullable: false),
                        CaKham_MaCa = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.DonNghiPhep_Id, t.CaKham_MaCa });
            
            DropForeignKey("dbo.CaNghi", "DonNghiPhepId", "dbo.DonNghiPhep");
            DropForeignKey("dbo.CaNghi", "MaCa", "dbo.CaKham");
            DropIndex("dbo.CaNghi", new[] { "MaCa" });
            DropIndex("dbo.CaNghi", new[] { "DonNghiPhepId" });
            DropTable("dbo.CaNghi");
            CreateIndex("dbo.DonNghiPhepCaKhams", "CaKham_MaCa");
            CreateIndex("dbo.DonNghiPhepCaKhams", "DonNghiPhep_Id");
            AddForeignKey("dbo.DonNghiPhepCaKhams", "CaKham_MaCa", "dbo.CaKham", "MaCa", cascadeDelete: true);
            AddForeignKey("dbo.DonNghiPhepCaKhams", "DonNghiPhep_Id", "dbo.DonNghiPhep", "Id", cascadeDelete: true);
        }
    }
}
