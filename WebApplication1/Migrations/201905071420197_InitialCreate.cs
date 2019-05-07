namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Book",
                c => new
                    {
                        Book_Id = c.Int(nullable: false),
                        Book_Name = c.String(nullable: false),
                        Book_Author = c.String(),
                        Book_BoughtDate = c.DateTime(nullable: false),
                        Book_Publisher = c.String(),
                        Book_Note = c.String(),
                        Book_Status = c.String(),
                        Book_Keeper = c.String(),
                        Create_Date = c.DateTime(nullable: false),
                        Create_User = c.String(),
                        Modify_Date = c.DateTime(nullable: false),
                        Modify_User = c.String(),
                    })
                .PrimaryKey(t => t.Book_Id);
            
            CreateTable(
                "dbo.Borrow",
                c => new
                    {
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Book_Id = c.Int(nullable: false),
                        Code_Id = c.String(nullable: false, maxLength: 128),
                        Status = c.String(),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Book_Id, t.Code_Id })
                .ForeignKey("dbo.Book", t => t.Book_Id, cascadeDelete: true)
                .ForeignKey("dbo.Member", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Book_Id);
            
            CreateTable(
                "dbo.Member",
                c => new
                    {
                        User_Id = c.String(nullable: false, maxLength: 128),
                        User_CName = c.String(nullable: false),
                        User_EName = c.String(),
                        Create_Date = c.DateTime(),
                        Create_User = c.String(),
                        Modify_Date = c.DateTime(),
                        Modify_User = c.String(),
                    })
                .PrimaryKey(t => t.User_Id);
            
            CreateTable(
                "dbo.Book_Data",
                c => new
                    {
                        Book_Id = c.Int(nullable: false),
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Code_Id = c.String(nullable: false, maxLength: 128),
                        Book_Class_Id = c.String(nullable: false, maxLength: 128),
                        Book_Name = c.String(),
                        Book_Author = c.String(),
                        Book_Bought_Date = c.DateTime(),
                        Book_Publisher = c.String(),
                        Book_Note = c.String(),
                        Book_Status = c.String(),
                        Book_Keeper = c.String(),
                        Create_Date = c.DateTime(),
                        Create_User = c.String(),
                        Modify_Date = c.DateTime(),
                        Modify_User = c.String(),
                    })
                .PrimaryKey(t => new { t.Book_Id, t.User_Id, t.Code_Id, t.Book_Class_Id })
                .ForeignKey("dbo.Book_Class", t => t.Book_Class_Id, cascadeDelete: true)
                .ForeignKey("dbo.Book_Code", t => t.Code_Id, cascadeDelete: true)
                .ForeignKey("dbo.Member", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Code_Id)
                .Index(t => t.Book_Class_Id);
            
            CreateTable(
                "dbo.Book_Class",
                c => new
                    {
                        Book_Class_Id = c.String(nullable: false, maxLength: 128),
                        Book_Class_Name = c.String(),
                        Create_Date = c.DateTime(),
                        Create_User = c.String(),
                        Modify_Date = c.DateTime(),
                        Modify_user = c.String(),
                    })
                .PrimaryKey(t => t.Book_Class_Id);
            
            CreateTable(
                "dbo.Book_Code",
                c => new
                    {
                        Code_Id = c.String(nullable: false, maxLength: 128),
                        Code_Type = c.String(),
                        Code_Type_Desc = c.String(),
                        Code_Name = c.String(),
                        Create_Date = c.DateTime(),
                        Create_User = c.String(),
                        Modify_Date = c.DateTime(),
                        Modify_User = c.String(),
                    })
                .PrimaryKey(t => t.Code_Id);
            
            CreateTable(
                "dbo.Code",
                c => new
                    {
                        Code_Id = c.String(nullable: false, maxLength: 128),
                        Code_Type = c.String(nullable: false),
                        Code_Name = c.String(),
                        Code_TypeDesc = c.String(),
                        Create_Date = c.DateTime(nullable: false),
                        Create_User = c.String(),
                        Modify_Date = c.DateTime(nullable: false),
                        Modify_User = c.String(),
                        Borrows_User_Id = c.String(maxLength: 128),
                        Borrows_Book_Id = c.Int(),
                        Borrows_Code_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Code_Id)
                .ForeignKey("dbo.Borrow", t => new { t.Borrows_User_Id, t.Borrows_Book_Id, t.Borrows_Code_Id })
                .Index(t => new { t.Borrows_User_Id, t.Borrows_Book_Id, t.Borrows_Code_Id });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Code", new[] { "Borrows_User_Id", "Borrows_Book_Id", "Borrows_Code_Id" }, "dbo.Borrow");
            DropForeignKey("dbo.Borrow", "User_Id", "dbo.Member");
            DropForeignKey("dbo.Book_Data", "User_Id", "dbo.Member");
            DropForeignKey("dbo.Book_Data", "Code_Id", "dbo.Book_Code");
            DropForeignKey("dbo.Book_Data", "Book_Class_Id", "dbo.Book_Class");
            DropForeignKey("dbo.Borrow", "Book_Id", "dbo.Book");
            DropIndex("dbo.Code", new[] { "Borrows_User_Id", "Borrows_Book_Id", "Borrows_Code_Id" });
            DropIndex("dbo.Book_Data", new[] { "Book_Class_Id" });
            DropIndex("dbo.Book_Data", new[] { "Code_Id" });
            DropIndex("dbo.Book_Data", new[] { "User_Id" });
            DropIndex("dbo.Borrow", new[] { "Book_Id" });
            DropIndex("dbo.Borrow", new[] { "User_Id" });
            DropTable("dbo.Code");
            DropTable("dbo.Book_Code");
            DropTable("dbo.Book_Class");
            DropTable("dbo.Book_Data");
            DropTable("dbo.Member");
            DropTable("dbo.Borrow");
            DropTable("dbo.Book");
        }
    }
}
