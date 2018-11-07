namespace WorldwideMovieDatabase.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableDeathDate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Profiles", "DeathDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Profiles", "DeathDate", c => c.DateTime(nullable: true));
        }
    }
}
