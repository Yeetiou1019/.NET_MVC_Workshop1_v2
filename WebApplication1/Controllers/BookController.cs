using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.DAL;
using WebApplication1.Models;
using PagedList;

namespace WebApplication1.Controllers
{
    public class BookController : Controller
    {
        private BookService db = new BookService();

        // GET: Book
        public ActionResult Index(string sortOrder,string searchString , string BookStatusList, string BookKeeperList, int? page ,string currentFilter,string BookClassNameList)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var books = from s in db.Books
                           select s;

            var classes = from cs in db.Classes
                          select cs;

            //var StatusQry = (from d in db.Books
            //                orderby d.Book_Status
            //                select d.Book_Status).Distinct();

            //var StatusList = new List<string>();
            //StatusList.AddRange(StatusQry.Distinct());
            //ViewBag.BookStatusList = new SelectList(StatusList);

            List<SelectListItem> StatusList = new List<SelectListItem>();
            StatusList.Add(new SelectListItem { Text = "", Value = "",Selected =true });
            StatusList.Add(new SelectListItem { Text = "可以借出", Value = "A" });
            StatusList.Add(new SelectListItem { Text = "已借出", Value = "B" });
            StatusList.Add(new SelectListItem { Text = "不可借出", Value = "U" });
            StatusList.Add(new SelectListItem { Text = "已借出(未領)", Value = "C" });
            
            ViewBag.StatusList = StatusList;


            var KeeperQry = (from d in db.Books
                             orderby d.Book_Keeper
                             select d.Book_Keeper).Distinct();
            var KeeperList = new List<string>();
            KeeperList.Add("");
            KeeperList.AddRange(KeeperQry.Distinct());
            
            ViewBag.BookKeeperList = new SelectList(KeeperList);

            var BookClassQry = (from d in db.Classes
                             orderby d.Book_Class_Name
                             select d.Book_Class_Name).Distinct();
            var ClassNameList = new List<string>();
            ClassNameList.Add("");
            ClassNameList.AddRange(BookClassQry.Distinct());
            
            ViewBag.BookClassNameList = new SelectList(ClassNameList);

            if (String.IsNullOrEmpty(searchString))
            {
                searchString = null;
            }
            else
            {
                books = books.Where(s => s.Book_Name.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(x => x.Book_Status == BookStatusList);
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(y => y.Book_Keeper == BookKeeperList);
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                classes = classes.Where(z => z.Book_Class_Name == BookClassNameList);
            }

            switch (sortOrder)
            {
                case "name_desc":
                    books = books.OrderByDescending(s => s.Book_Name);
                    break;
                case "Date":
                    books = books.OrderBy(s => s.Book_BoughtDate);
                    break;
                case "date_desc":
                    books = books.OrderByDescending(s => s.Book_BoughtDate);
                    break;
                default:
                    books = books.OrderBy(s => s.Book_Name);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(books.ToPagedList(pageNumber, pageSize));
        }

        // GET: Book/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            DateTime date = DateTime.Now;
            ViewBag.Date = date;

            return View();
        }

        // POST: Book/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Book_Id,Book_Name,Book_Author,Book_BoughtDate,Book_Publisher,Book_Note,Book_Status,Book_Keeper,Create_Date,Create_User,Modify_Date,Modify_User")] Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    db.Books.Add(book);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (DataException /* dex */)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }

            return View(book);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Book_Id,Book_Name,Book_Author,Book_BoughtDate,Book_Publisher,Book_Note,Book_Status,Book_Keeper,Create_Date,Create_User,Modify_Date,Modify_User")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Book book = db.Books.Find(id);
                db.Books.Remove(book);
                db.SaveChanges();
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
