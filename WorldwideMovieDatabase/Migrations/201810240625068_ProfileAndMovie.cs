namespace WorldwideMovieDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfileAndMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ReleaseYear = c.DateTime(nullable: false),
                        UserRating = c.Double(nullable: false),
                        MPAARating = c.String(),
                        MovieLength = c.Time(nullable: false, precision: 7),
                        Genre = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BirthDate = c.DateTime(nullable: false),
                        DeathDate = c.DateTime(nullable: false),
                        Bio = c.String(),
                        ProfilePicture = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProfileMovies",
                c => new
                    {
                        Profile_ID = c.Int(nullable: false),
                        Movie_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Profile_ID, t.Movie_ID })
                .ForeignKey("dbo.Profiles", t => t.Profile_ID, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_ID, cascadeDelete: true)
                .Index(t => t.Profile_ID)
                .Index(t => t.Movie_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfileMovies", "Movie_ID", "dbo.Movies");
            DropForeignKey("dbo.ProfileMovies", "Profile_ID", "dbo.Profiles");
            DropIndex("dbo.ProfileMovies", new[] { "Movie_ID" });
            DropIndex("dbo.ProfileMovies", new[] { "Profile_ID" });
            DropTable("dbo.ProfileMovies");
            DropTable("dbo.Profiles");
            DropTable("dbo.Movies");
        }
    }
}
