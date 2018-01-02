using Library.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private BookDBContext db = new BookDBContext();

        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        //GET: Book/Search
        public ActionResult Search()
        {
            return View();
        }

        //GET: Book/Search
        [HttpPost]
        public ActionResult Search(FormCollection collection)
        {
            try
            {
                string Title = collection.Get("Title");
                string ISBN = collection.Get("ISBN");
                string Author = collection.Get("Author");

                if (Title == "" && ISBN == "" && Author == "")
                {
                    return View();
                }

                var Books = db.Books.ToList();

                if ("" != Title)
                {
                    Books = Books.Where(c => c.Title.Contains(Title)).ToList();
                }

                if ("" != ISBN)
                {
                    Books = Books.Where(c => c.ISBN == ISBN).ToList();
                }

                if ("" != Author)
                {
                    Books = Books.Where(c => c.Author.Contains(Author)).ToList();
                }

                TempData["Books"] = Books;

                return RedirectToAction("List");
            }
            catch
            {
                return View();
            }
        }

        //GET: Book/List
        [ActionName("List")]
        public ActionResult List()
        {
            var Books = TempData["Books"];

            return View(Books);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            var book = db.Books.Find(id);

            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                var db = new BookDBContext();
                var book = new Book { Title = collection.Get("Title"), ISBN = collection.Get("ISBN"), Author = collection.Get("Author"), Description = collection.Get("Description") };
                db.Books.Add(book);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            var Book = db.Books.Find(id);
            if (Book == null)
            {
                return HttpNotFound();
            }
            return View(Book);
        }

        // POST: Book/Edit
        [HttpPost]
        public ActionResult Edit([Bind(Include = "Id,Title,ISBN,Author,Description")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = book.Id});
            }
            return View(book);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}
