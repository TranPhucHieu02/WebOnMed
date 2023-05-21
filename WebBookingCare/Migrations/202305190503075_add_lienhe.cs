namespace WebBookingCare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_lienhe : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LienHes",
                c => new
                    {
                        MaLH = c.String(nullable: false, maxLength: 50),
                        HoTen = c.String(),
                        Email = c.String(),
                        SDT = c.String(),
                        ChuDe = c.String(maxLength: 500),
                        MoiDung = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.MaLH);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.LienHes");
        }
    }
}
