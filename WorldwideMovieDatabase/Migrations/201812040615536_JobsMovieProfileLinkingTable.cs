namespace WorldwideMovieDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JobsMovieProfileLinkingTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MovieProfiles", "JobId", "dbo.Jobs");
            DropIndex("dbo.MovieProfiles", new[] { "JobId" });
            CreateTable(
                "dbo.MovieProfileJobs",
                c => new
                    {
                        MovieProfile_MovieProfileId = c.Int(nullable: false),
                        Job_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MovieProfile_MovieProfileId, t.Job_Id })
                .ForeignKey("dbo.MovieProfiles", t => t.MovieProfile_MovieProfileId, cascadeDelete: true)
                .ForeignKey("dbo.Jobs", t => t.Job_Id, cascadeDelete: true)
                .Index(t => t.MovieProfile_MovieProfileId)
                .Index(t => t.Job_Id);
            
            DropColumn("dbo.Jobs", "MoneyEarned");
            DropColumn("dbo.MovieProfiles", "JobId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovieProfiles", "JobId", c => c.Int());
            AddColumn("dbo.Jobs", "MoneyEarned", c => c.Double(nullable: false));
            DropForeignKey("dbo.MovieProfileJobs", "Job_Id", "dbo.Jobs");
            DropForeignKey("dbo.MovieProfileJobs", "MovieProfile_MovieProfileId", "dbo.MovieProfiles");
            DropIndex("dbo.MovieProfileJobs", new[] { "Job_Id" });
            DropIndex("dbo.MovieProfileJobs", new[] { "MovieProfile_MovieProfileId" });
            DropTable("dbo.MovieProfileJobs");
            CreateIndex("dbo.MovieProfiles", "JobId");
            AddForeignKey("dbo.MovieProfiles", "JobId", "dbo.Jobs", "Id");
        }
    }
}
