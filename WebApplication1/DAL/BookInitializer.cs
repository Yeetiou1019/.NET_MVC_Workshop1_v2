using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebApplication1.Models;

namespace WebApplication1.DAL
{
    public class BookInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<BookService>
    {
        protected override void Seed(BookService service)
        {
            var books = new List<Book>
            {
            new Book{Book_Id=2,Book_Name="Java",Book_Author="Mr.Chen",Book_BoughtDate=DateTime.Parse("2005-09-01"),Book_Publisher="NKUST",Book_Note="Java Class Beginning ",Book_Status="A",Book_Keeper="Tenso",Create_Date=DateTime.Parse("2010-10-09"),Create_User="HowHow",Modify_Date=DateTime.Parse("2013-03-01"),Modify_User="HowHow"},
            new Book{Book_Id=3,Book_Name="人類學",Book_Author="Duo",Book_BoughtDate=DateTime.Parse("2013-09-01"),Book_Publisher="NKUST",Book_Note="人類文化 ",Book_Status="B",Book_Keeper="Xuan",Create_Date=DateTime.Parse("2015-01-01"),Create_User="PeiYee",Modify_Date=DateTime.Parse("2019-01-11"),Modify_User="GuoDong"},
            new Book{Book_Id=4,Book_Name="微積分",Book_Author="Wei",Book_BoughtDate=DateTime.Parse("2015-09-01"),Book_Publisher="NKUST",Book_Note="微分與積分",Book_Status="U",Book_Keeper="Yee",Create_Date=DateTime.Parse("2016-08-07"),Create_User="GuoDong",Modify_Date=DateTime.Parse("2018-03-02"),Modify_User="PeiYee"},
            };

            books.ForEach(s => service.Books.Add(s));
            service.SaveChanges();
            var codes = new List<Code>
            {
            new Code{Code_Id="1",Code_Name="第一類",Code_TypeDesc="程式語言",Code_Type="Programming",Create_Date=DateTime.Parse("2019-10-10"),Create_User="Yee",Modify_Date=DateTime.Parse("2019-10-10"),Modify_User="Yee"},
            new Code{Code_Id="2",Code_Name="第二類",Code_TypeDesc="文化",Code_Type="Cluture",Create_Date=DateTime.Parse("2019-10-10"),Create_User="Yee",Modify_Date=DateTime.Parse("2019-10-10"),Modify_User="Yee"},
            new Code{Code_Id="3",Code_Name="第三類",Code_TypeDesc="數學",Code_Type="Math",Create_Date=DateTime.Parse("2019-10-10"),Create_User="Yee",Modify_Date=DateTime.Parse("2019-10-10"),Modify_User="Yee"},
         
            };
            codes.ForEach(s => service.Codes.Add(s));
            service.SaveChanges();
            var members = new List<Member>
            {
            new Member{User_Id="1",User_CName="陳沂",User_EName="Yee",Create_Date=DateTime.Parse("2009-10-19")},
            new Member{User_Id="2",User_CName="阿偉",User_EName="Wei",Create_Date=DateTime.Parse("2008-11-29")},
            new Member{User_Id="3",User_CName="小多",User_EName="Duo",Create_Date=DateTime.Parse("2010-12-19")},
            };
            members.ForEach(s => service.Members.Add(s));
            service.SaveChanges();

      
            var borrow = new List<Borrow>
            {
            new Borrow{User_Id="1",Book_Id=2,Code_Id="1",Status="A"},
            new Borrow{User_Id="2",Book_Id=4,Code_Id="2",Status="B"},
            new Borrow{User_Id="3",Book_Id=3,Code_Id="3",Status="C"},
            };
            borrow.ForEach(s => service.Borrows.Add(s));
            service.SaveChanges();
        }
    }
}