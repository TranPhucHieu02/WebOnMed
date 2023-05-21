namespace WebBookingCare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class up_lienhe1 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.LienHes");
            AlterColumn("dbo.LienHes", "MaLH", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.LienHes", "MaLH");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.LienHes");
            AlterColumn("dbo.LienHes", "MaLH", c => c.String(nullable: false, maxLength: 50));
            AddPrimaryKey("dbo.LienHes", "MaLH");
        }
    }
}
