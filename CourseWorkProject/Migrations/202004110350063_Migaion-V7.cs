namespace CourseWorkProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigaionV7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChatBoxes",
                c => new
                    {
                        ChatBoxId = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ChatBoxId)
                .ForeignKey("dbo.Users", t => t.ChatBoxId)
                .Index(t => t.ChatBoxId);
            
            CreateTable(
                "dbo.Chats",
                c => new
                    {
                        ChatId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        CreatedDate = c.DateTime(),
                        ChatBox_ChatBoxId = c.Int(),
                        User_id = c.Int(),
                    })
                .PrimaryKey(t => t.ChatId)
                .ForeignKey("dbo.ChatBoxes", t => t.ChatBox_ChatBoxId)
                .ForeignKey("dbo.Users", t => t.User_id)
                .Index(t => t.ChatBox_ChatBoxId)
                .Index(t => t.User_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChatBoxes", "ChatBoxId", "dbo.Users");
            DropForeignKey("dbo.Chats", "User_id", "dbo.Users");
            DropForeignKey("dbo.Chats", "ChatBox_ChatBoxId", "dbo.ChatBoxes");
            DropIndex("dbo.Chats", new[] { "User_id" });
            DropIndex("dbo.Chats", new[] { "ChatBox_ChatBoxId" });
            DropIndex("dbo.ChatBoxes", new[] { "ChatBoxId" });
            DropTable("dbo.Chats");
            DropTable("dbo.ChatBoxes");
        }
    }
}
