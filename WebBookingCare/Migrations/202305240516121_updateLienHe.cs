﻿namespace WebBookingCare.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateLienHe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LienHes", "ThoiGian", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LienHes", "ThoiGian");
        }
    }
}
