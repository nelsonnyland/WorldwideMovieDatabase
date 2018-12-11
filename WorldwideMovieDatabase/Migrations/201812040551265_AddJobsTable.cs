namespace WorldwideMovieDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddJobsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        MoneyEarned = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.MovieProfiles", "JobId", c => c.Int());
            CreateIndex("dbo.MovieProfiles", "JobId");
            AddForeignKey("dbo.MovieProfiles", "JobId", "dbo.Jobs", "Id");
            DropColumn("dbo.MovieProfiles", "JobTitle");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MovieProfiles", "JobTitle", c => c.String());
            DropForeignKey("dbo.MovieProfiles", "JobId", "dbo.Jobs");
            DropIndex("dbo.MovieProfiles", new[] { "JobId" });
            DropColumn("dbo.MovieProfiles", "JobId");
            DropTable("dbo.Jobs");
        }
    }
}
