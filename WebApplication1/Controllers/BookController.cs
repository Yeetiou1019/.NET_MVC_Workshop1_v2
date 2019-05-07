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
        public ActionResult Index(string sortOrder,string searchString , string BookStatusList,int? page ,string currentFilter)
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

            var StatusQry = (from d in db.Books
                            orderby d.Book_Status
                            select d.Book_Status).Distinct();

            var StatusList = new List<string>();
            StatusList.AddRange(StatusQry.Distinct());
            ViewBag.BookStatusList = new SelectList(StatusList);

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Book_Name.Contains(searchString));
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Book_Status == BookStatusList);
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
