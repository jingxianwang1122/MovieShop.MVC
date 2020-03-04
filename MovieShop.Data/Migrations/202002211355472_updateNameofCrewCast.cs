namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateNameofCrewCast : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Casts", newName: "Cast");
            RenameTable(name: "dbo.Crews", newName: "Crew");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Crew", newName: "Crews");
            RenameTable(name: "dbo.Cast", newName: "Casts");
        }
    }
}
