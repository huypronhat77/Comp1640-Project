namespace CourseWorkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationV2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "FileName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "FileName");
        }
    }
}
