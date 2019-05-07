namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Book_Class_Id : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Book_Data");
            CreateTable(
                "dbo.Class",
                c => new
                    {
                        Book_Class_Id = c.String(nullable: false, maxLength: 128),
                        Book_Class_Name = c.String(nullable: false),
                        Create_Date = c.DateTime(nullable: false),
                        Create_User = c.String(),
                        Modify_Date = c.DateTime(nullable: false),
                        Modify_User = c.String(),
                    })
                .PrimaryKey(t => t.Book_Class_Id);
            
            AddColumn("dbo.Book", "Book_Class_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Member", "User_CName", c => c.String());
            AddPrimaryKey("dbo.Book_Data", new[] { "Book_Id", "Book_Class_Id", "Code_Id", "User_Id" });
            CreateIndex("dbo.Book", "Book_Class_Id");
            AddForeignKey("dbo.Book", "Book_Class_Id", "dbo.Class", "Book_Class_Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Book", "Book_Class_Id", "dbo.Class");
            DropIndex("dbo.Book", new[] { "Book_Class_Id" });
            DropPrimaryKey("dbo.Book_Data");
            AlterColumn("dbo.Member", "User_CName", c => c.String(nullable: false));
            DropColumn("dbo.Book", "Book_Class_Id");
            DropTable("dbo.Class");
            AddPrimaryKey("dbo.Book_Data", new[] { "Book_Id", "User_Id", "Code_Id", "Book_Class_Id" });
        }
    }
}
