namespace WorldwideMovieDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobTitleTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ProfileMovies", newName: "MovieProfiles");
            DropPrimaryKey("dbo.MovieProfiles");
            CreateTable(
                "dbo.JobTitles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProfileJobTitles",
                c => new
                    {
                        Profile_ID = c.Int(nullable: false),
                        JobTitle_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Profile_ID, t.JobTitle_Id })
                .ForeignKey("dbo.Profiles", t => t.Profile_ID, cascadeDelete: true)
                .ForeignKey("dbo.JobTitles", t => t.JobTitle_Id, cascadeDelete: true)
                .Index(t => t.Profile_ID)
                .Index(t => t.JobTitle_Id);
            
            AddPrimaryKey("dbo.MovieProfiles", new[] { "Movie_ID", "Profile_ID" });
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfileJobTitles", "JobTitle_Id", "dbo.JobTitles");
            DropForeignKey("dbo.ProfileJobTitles", "Profile_ID", "dbo.Profiles");
            DropIndex("dbo.ProfileJobTitles", new[] { "JobTitle_Id" });
            DropIndex("dbo.ProfileJobTitles", new[] { "Profile_ID" });
            DropPrimaryKey("dbo.MovieProfiles");
            DropTable("dbo.ProfileJobTitles");
            DropTable("dbo.JobTitles");
            AddPrimaryKey("dbo.MovieProfiles", new[] { "Profile_ID", "Movie_ID" });
            RenameTable(name: "dbo.MovieProfiles", newName: "ProfileMovies");
        }
    }
}
