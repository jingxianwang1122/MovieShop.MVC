namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateunknown : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movie", "CreatedDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movie", "CreatedDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
        }
    }
}
