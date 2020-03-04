namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateurlname : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Cast", "TmdbUrl", c => c.String());
            AddColumn("dbo.Crew", "TmdbUrl", c => c.String());
            AlterColumn("dbo.Cast", "ProfilePath", c => c.String(maxLength: 2084));
            AlterColumn("dbo.Crew", "Name", c => c.String(maxLength: 128));
            DropColumn("dbo.Cast", "TmbUrl");
            DropColumn("dbo.Crew", "TmdUrl");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Crew", "TmdUrl", c => c.String());
            AddColumn("dbo.Cast", "TmbUrl", c => c.String());
            AlterColumn("dbo.Crew", "Name", c => c.String());
            AlterColumn("dbo.Cast", "ProfilePath", c => c.String(maxLength: 2048));
            DropColumn("dbo.Crew", "TmdbUrl");
            DropColumn("dbo.Cast", "TmdbUrl");
        }
    }
}
