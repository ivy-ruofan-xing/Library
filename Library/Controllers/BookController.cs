using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View();
        }

        //GET: Book/List
        public ActionResult List()
        {
            var books = db.Books.Where(c => c.Title == "").ToList();
            return View(books);
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
            return View();
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
