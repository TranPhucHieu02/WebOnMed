namespace WebBookingCare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class udpnp : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DonNghiPhep", "CaKham_MaCa", c => c.String(maxLength: 50));
            AddColumn("dbo.DonNghiPhep", "CaKham_MaCa1", c => c.String(maxLength: 50));
            CreateIndex("dbo.DonNghiPhep", "CaKham_MaCa");
            CreateIndex("dbo.DonNghiPhep", "CaKham_MaCa1");
            AddForeignKey("dbo.DonNghiPhep", "CaKham_MaCa", "dbo.CaKham", "MaCa");
            AddForeignKey("dbo.DonNghiPhep", "CaKham_MaCa1", "dbo.CaKham", "MaCa");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DonNghiPhep", "CaKham_MaCa1", "dbo.CaKham");
            DropForeignKey("dbo.DonNghiPhep", "CaKham_MaCa", "dbo.CaKham");
            DropIndex("dbo.DonNghiPhep", new[] { "CaKham_MaCa1" });
            DropIndex("dbo.DonNghiPhep", new[] { "CaKham_MaCa" });
            DropColumn("dbo.DonNghiPhep", "CaKham_MaCa1");
            DropColumn("dbo.DonNghiPhep", "CaKham_MaCa");
        }
    }
}
