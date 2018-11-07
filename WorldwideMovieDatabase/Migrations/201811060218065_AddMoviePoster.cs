namespace WorldwideMovieDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMoviePoster : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "MoviePoster", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "MoviePoster");
        }
    }
}
