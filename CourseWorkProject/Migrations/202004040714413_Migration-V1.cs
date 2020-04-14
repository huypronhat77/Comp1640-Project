namespace CourseWorkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrationV1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        User_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.User_id)
                .Index(t => t.User_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Blogs", "User_id", "dbo.Users");
            DropIndex("dbo.Blogs", new[] { "User_id" });
            DropTable("dbo.Blogs");
        }
    }
}
