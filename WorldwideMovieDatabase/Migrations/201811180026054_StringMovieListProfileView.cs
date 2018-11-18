namespace WorldwideMovieDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class StringMovieListProfileView : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProfileMovies", "Profile_ID", "dbo.Profiles");
            DropForeignKey("dbo.ProfileMovies", "Movie_ID", "dbo.Movies");
            DropIndex("dbo.ProfileMovies", new[] { "Profile_ID" });
            DropIndex("dbo.ProfileMovies", new[] { "Movie_ID" });
            AddColumn("dbo.Profiles", "Movie_ID", c => c.Int());
            CreateIndex("dbo.Profiles", "Movie_ID");
            AddForeignKey("dbo.Profiles", "Movie_ID", "dbo.Movies", "ID");
            DropTable("dbo.ProfileMovies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProfileMovies",
                c => new
                    {
                        Profile_ID = c.Int(nullable: false),
                        Movie_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Profile_ID, t.Movie_ID });
            
            DropForeignKey("dbo.Profiles", "Movie_ID", "dbo.Movies");
            DropIndex("dbo.Profiles", new[] { "Movie_ID" });
            DropColumn("dbo.Profiles", "Movie_ID");
            CreateIndex("dbo.ProfileMovies", "Movie_ID");
            CreateIndex("dbo.ProfileMovies", "Profile_ID");
            AddForeignKey("dbo.ProfileMovies", "Movie_ID", "dbo.Movies", "ID", cascadeDelete: true);
            AddForeignKey("dbo.ProfileMovies", "Profile_ID", "dbo.Profiles", "ID", cascadeDelete: true);
        }
    }
}
