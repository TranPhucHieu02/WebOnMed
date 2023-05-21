namespace WebBookingCare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_lh : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.LienHe");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.LienHe",
                c => new
                    {
                        MaLH = c.String(nullable: false, maxLength: 50),
                        HoTen = c.String(),
                        Email = c.String(),
                        SDT = c.String(),
                        ChuDe = c.String(maxLength: 500),
                        NoiDung = c.String(maxLength: 500),
                    })
                .PrimaryKey(t => t.MaLH);
            
        }
    }
}
