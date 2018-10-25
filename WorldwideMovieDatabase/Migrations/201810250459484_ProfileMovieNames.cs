namespace WorldwideMovieDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProfileMovieNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Movies", "ReleaseYear");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "ReleaseYear", c => c.DateTime(nullable: false));
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
