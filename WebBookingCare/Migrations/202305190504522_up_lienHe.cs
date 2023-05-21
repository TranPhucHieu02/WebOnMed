namespace WebBookingCare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up_lienHe : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.LienHes");
            AddColumn("dbo.LienHes", "NoiDung", c => c.String(maxLength: 500));
            AlterColumn("dbo.LienHes", "MaLH", c => c.String(nullable: false, maxLength: 50));
            AddPrimaryKey("dbo.LienHes", "MaLH");
            DropColumn("dbo.LienHes", "MoiDung");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LienHes", "MoiDung", c => c.String(maxLength: 500));
            DropPrimaryKey("dbo.LienHes");
            AlterColumn("dbo.LienHes", "MaLH", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.LienHes", "NoiDung");
            AddPrimaryKey("dbo.LienHes", "MaLH");
        }
    }
}
