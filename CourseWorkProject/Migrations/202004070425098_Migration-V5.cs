namespace CourseWorkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationV5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        Blog_id = c.Int(),
                        User_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Blogs", t => t.Blog_id)
                .ForeignKey("dbo.Users", t => t.User_id)
                .Index(t => t.Blog_id)
                .Index(t => t.User_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "User_id", "dbo.Users");
            DropForeignKey("dbo.Comments", "Blog_id", "dbo.Blogs");
            DropIndex("dbo.Comments", new[] { "User_id" });
            DropIndex("dbo.Comments", new[] { "Blog_id" });
            DropTable("dbo.Comments");
        }
    }
}
