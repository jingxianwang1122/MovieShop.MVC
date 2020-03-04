namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "TwoFactorEnabled", c => c.Boolean());
            AlterColumn("dbo.User", "DateOfBirth", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.User", "Email", c => c.String(maxLength: 256));
            AlterColumn("dbo.User", "LockoutEndDate", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.User", "LastLoginDateTime", c => c.DateTime(precision: 7, storeType: "datetime2"));
            AlterColumn("dbo.User", "IsLocked", c => c.Boolean());
            DropColumn("dbo.User", "TwoFactorEnable");
        }
        
        public override void Down()
        {
            AddColumn("dbo.User", "TwoFactorEnable", c => c.Boolean(nullable: false));
            AlterColumn("dbo.User", "IsLocked", c => c.Boolean(nullable: false));
            AlterColumn("dbo.User", "LastLoginDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.User", "LockoutEndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.User", "Email", c => c.String(maxLength: 1024));
            AlterColumn("dbo.User", "DateOfBirth", c => c.DateTime(nullable: false));
            DropColumn("dbo.User", "TwoFactorEnabled");
        }
    }
}
