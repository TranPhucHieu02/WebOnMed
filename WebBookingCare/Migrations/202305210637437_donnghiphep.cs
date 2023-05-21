namespace WebBookingCare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class donnghiphep : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DonNghiPhep",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NgayNghi = c.DateTime(nullable: false),
                        TrangThai = c.Boolean(nullable: false),
                        MaBS = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BacSi", t => t.MaBS)
                .Index(t => t.MaBS);
            
            AddColumn("dbo.CaKham", "DonNghiPhep_Id", c => c.Int());
            CreateIndex("dbo.CaKham", "DonNghiPhep_Id");
            AddForeignKey("dbo.CaKham", "DonNghiPhep_Id", "dbo.DonNghiPhep", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CaKham", "DonNghiPhep_Id", "dbo.DonNghiPhep");
            DropForeignKey("dbo.DonNghiPhep", "MaBS", "dbo.BacSi");
            DropIndex("dbo.DonNghiPhep", new[] { "MaBS" });
            DropIndex("dbo.CaKham", new[] { "DonNghiPhep_Id" });
            DropColumn("dbo.CaKham", "DonNghiPhep_Id");
            DropTable("dbo.DonNghiPhep");
        }
    }
}
