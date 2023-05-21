namespace WebBookingCare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_dnp : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DonNghiPhep", "CaKham_MaCa", "dbo.CaKham");
            DropForeignKey("dbo.CaKham", "DonNghiPhep_Id", "dbo.DonNghiPhep");
            DropForeignKey("dbo.DonNghiPhep", "CaKham_MaCa1", "dbo.CaKham");
            DropIndex("dbo.CaKham", new[] { "DonNghiPhep_Id" });
            DropIndex("dbo.DonNghiPhep", new[] { "CaKham_MaCa" });
            DropIndex("dbo.DonNghiPhep", new[] { "CaKham_MaCa1" });
            CreateTable(
                "dbo.DonNghiPhepCaKhams",
                c => new
                    {
                        DonNghiPhep_Id = c.Int(nullable: false),
                        CaKham_MaCa = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => new { t.DonNghiPhep_Id, t.CaKham_MaCa })
                .ForeignKey("dbo.DonNghiPhep", t => t.DonNghiPhep_Id, cascadeDelete: true)
                .ForeignKey("dbo.CaKham", t => t.CaKham_MaCa, cascadeDelete: true)
                .Index(t => t.DonNghiPhep_Id)
                .Index(t => t.CaKham_MaCa);
            
            DropColumn("dbo.CaKham", "DonNghiPhep_Id");
            DropColumn("dbo.DonNghiPhep", "CaKham_MaCa");
            DropColumn("dbo.DonNghiPhep", "CaKham_MaCa1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DonNghiPhep", "CaKham_MaCa1", c => c.String(maxLength: 50));
            AddColumn("dbo.DonNghiPhep", "CaKham_MaCa", c => c.String(maxLength: 50));
            AddColumn("dbo.CaKham", "DonNghiPhep_Id", c => c.Int());
            DropForeignKey("dbo.DonNghiPhepCaKhams", "CaKham_MaCa", "dbo.CaKham");
            DropForeignKey("dbo.DonNghiPhepCaKhams", "DonNghiPhep_Id", "dbo.DonNghiPhep");
            DropIndex("dbo.DonNghiPhepCaKhams", new[] { "CaKham_MaCa" });
            DropIndex("dbo.DonNghiPhepCaKhams", new[] { "DonNghiPhep_Id" });
            DropTable("dbo.DonNghiPhepCaKhams");
            CreateIndex("dbo.DonNghiPhep", "CaKham_MaCa1");
            CreateIndex("dbo.DonNghiPhep", "CaKham_MaCa");
            CreateIndex("dbo.CaKham", "DonNghiPhep_Id");
            AddForeignKey("dbo.DonNghiPhep", "CaKham_MaCa1", "dbo.CaKham", "MaCa");
            AddForeignKey("dbo.CaKham", "DonNghiPhep_Id", "dbo.DonNghiPhep", "Id");
            AddForeignKey("dbo.DonNghiPhep", "CaKham_MaCa", "dbo.CaKham", "MaCa");
        }
    }
}
