namespace WebBookingCare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update_cakham : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CaKham", "TrangThai", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CaKham", "TrangThai");
        }
    }
}
