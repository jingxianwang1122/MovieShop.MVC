namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateUserRole : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserRoles", newName: "UserRole");
            RenameColumn(table: "dbo.UserRole", name: "User_Id", newName: "RoleId");
            RenameColumn(table: "dbo.UserRole", name: "Role_Id", newName: "UserId");
            RenameIndex(table: "dbo.UserRole", name: "IX_Role_Id", newName: "IX_UserId");
            RenameIndex(table: "dbo.UserRole", name: "IX_User_Id", newName: "IX_RoleId");
            DropPrimaryKey("dbo.UserRole");
            AddPrimaryKey("dbo.UserRole", new[] { "UserId", "RoleId" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.UserRole");
            AddPrimaryKey("dbo.UserRole", new[] { "User_Id", "Role_Id" });
            RenameIndex(table: "dbo.UserRole", name: "IX_RoleId", newName: "IX_User_Id");
            RenameIndex(table: "dbo.UserRole", name: "IX_UserId", newName: "IX_Role_Id");
            RenameColumn(table: "dbo.UserRole", name: "UserId", newName: "Role_Id");
            RenameColumn(table: "dbo.UserRole", name: "RoleId", newName: "User_Id");
            RenameTable(name: "dbo.UserRole", newName: "UserRoles");
        }
    }
}
