namespace WebBookingCare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class udlh : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.LienHe");
            AlterColumn("dbo.LienHe", "MaLH", c => c.String(nullable: false, maxLength: 50));
            AddPrimaryKey("dbo.LienHe", "MaLH");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.LienHe");
            AlterColumn("dbo.LienHe", "MaLH", c => c.String(nullable: false, maxLength: 50));
            AddPrimaryKey("dbo.LienHe", "MaLH");
        }
    }
}
