namespace WorldwideMovieDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OptionalProfileAndMovieProperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime());
            AlterColumn("dbo.Movies", "UserRating", c => c.Double());
            AlterColumn("dbo.Movies", "MovieLength", c => c.Time(precision: 7));
            AlterColumn("dbo.Profiles", "BirthDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profiles", "BirthDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Movies", "MovieLength", c => c.Time(nullable: false, precision: 7));
            AlterColumn("dbo.Movies", "UserRating", c => c.Double(nullable: false));
            AlterColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
        }
    }
}
