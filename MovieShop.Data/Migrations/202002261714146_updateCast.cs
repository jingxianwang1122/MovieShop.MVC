﻿namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateCast : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cast", "Name", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Cast", "TmdbUrl", c => c.String(maxLength: 2084));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Cast", "TmdbUrl", c => c.String());
            AlterColumn("dbo.Cast", "Name", c => c.String(maxLength: 128));
        }
    }
}
