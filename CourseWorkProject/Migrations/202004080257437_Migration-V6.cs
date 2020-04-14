namespace CourseWorkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationV6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Blogs", "User_id", "dbo.Users");
            DropIndex("dbo.Blogs", new[] { "User_id" });
            AddColumn("dbo.Blogs", "Creator", c => c.String());
            AddColumn("dbo.Blogs", "Group_id", c => c.Int());
            CreateIndex("dbo.Blogs", "Group_id");
            AddForeignKey("dbo.Blogs", "Group_id", "dbo.Groups", "id");
            DropColumn("dbo.Blogs", "User_id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Blogs", "User_id", c => c.Int());
            DropForeignKey("dbo.Blogs", "Group_id", "dbo.Groups");
            DropIndex("dbo.Blogs", new[] { "Group_id" });
            DropColumn("dbo.Blogs", "Group_id");
            DropColumn("dbo.Blogs", "Creator");
            CreateIndex("dbo.Blogs", "User_id");
            AddForeignKey("dbo.Blogs", "User_id", "dbo.Users", "id");
        }
    }
}
