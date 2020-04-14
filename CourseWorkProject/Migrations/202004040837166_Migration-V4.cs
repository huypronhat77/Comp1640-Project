namespace CourseWorkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationV4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Blogs", "CreateDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "CreateDate", c => c.DateTime(nullable: false));
        }
    }
}
