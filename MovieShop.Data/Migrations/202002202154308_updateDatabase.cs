namespace MovieShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trailer", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.Movie", "User_Id", "dbo.User");
            DropIndex("dbo.Movie", new[] { "User_Id" });
            DropIndex("dbo.Trailer", new[] { "MovieId" });
            CreateTable(
                "dbo.Favorite",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Purchase",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PurchaseNumber = c.Guid(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchaseDateTime = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        MovieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MovieId);
            
            CreateTable(
                "dbo.Review",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        Rating = c.Decimal(nullable: false, precision: 3, scale: 2),
                        ReviewText = c.String(),
                    })
                .PrimaryKey(t => new { t.MovieId, t.UserId })
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.MovieCast",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        CastId = c.Int(nullable: false),
                        Character = c.String(nullable: false, maxLength: 450),
                    })
                .PrimaryKey(t => new { t.MovieId, t.CastId, t.Character })
                .ForeignKey("dbo.Casts", t => t.CastId, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.CastId);
            
            CreateTable(
                "dbo.Casts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 128),
                        Gender = c.String(),
                        TmbUrl = c.String(),
                        ProfilePath = c.String(maxLength: 2048),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MovieCrew",
                c => new
                    {
                        MovieId = c.Int(nullable: false),
                        CrewId = c.Int(nullable: false),
                        Department = c.String(nullable: false, maxLength: 128),
                        Job = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.MovieId, t.CrewId, t.Department, t.Job })
                .ForeignKey("dbo.Crews", t => t.CrewId, cascadeDelete: true)
                .ForeignKey("dbo.Movie", t => t.MovieId, cascadeDelete: true)
                .Index(t => t.MovieId)
                .Index(t => t.CrewId);
            
            CreateTable(
                "dbo.Crews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Gender = c.String(),
                        TmdUrl = c.String(),
                        ProfilePath = c.String(maxLength: 2084),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Movie", "Price", c => c.Decimal(precision: 5, scale: 2));
            DropColumn("dbo.Movie", "User_Id");
            DropTable("dbo.Trailer");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Trailer",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MovieId = c.Int(nullable: false),
                        TrailerUrl = c.String(maxLength: 2084),
                        Name = c.String(maxLength: 2084),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movie", "User_Id", c => c.Int());
            DropForeignKey("dbo.MovieCrew", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieCrew", "CrewId", "dbo.Crews");
            DropForeignKey("dbo.MovieCast", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.MovieCast", "CastId", "dbo.Casts");
            DropForeignKey("dbo.Review", "UserId", "dbo.User");
            DropForeignKey("dbo.Review", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.Purchase", "UserId", "dbo.User");
            DropForeignKey("dbo.Purchase", "MovieId", "dbo.Movie");
            DropForeignKey("dbo.Favorite", "UserId", "dbo.User");
            DropForeignKey("dbo.Favorite", "MovieId", "dbo.Movie");
            DropIndex("dbo.MovieCrew", new[] { "CrewId" });
            DropIndex("dbo.MovieCrew", new[] { "MovieId" });
            DropIndex("dbo.MovieCast", new[] { "CastId" });
            DropIndex("dbo.MovieCast", new[] { "MovieId" });
            DropIndex("dbo.Review", new[] { "UserId" });
            DropIndex("dbo.Review", new[] { "MovieId" });
            DropIndex("dbo.Purchase", new[] { "MovieId" });
            DropIndex("dbo.Purchase", new[] { "UserId" });
            DropIndex("dbo.Favorite", new[] { "UserId" });
            DropIndex("dbo.Favorite", new[] { "MovieId" });
            AlterColumn("dbo.Movie", "Price", c => c.Decimal(precision: 18, scale: 2));
            DropTable("dbo.Crews");
            DropTable("dbo.MovieCrew");
            DropTable("dbo.Casts");
            DropTable("dbo.MovieCast");
            DropTable("dbo.Review");
            DropTable("dbo.Purchase");
            DropTable("dbo.Favorite");
            CreateIndex("dbo.Trailer", "MovieId");
            CreateIndex("dbo.Movie", "User_Id");
            AddForeignKey("dbo.Movie", "User_Id", "dbo.User", "Id");
            AddForeignKey("dbo.Trailer", "MovieId", "dbo.Movie", "Id", cascadeDelete: true);
        }
    }
}
