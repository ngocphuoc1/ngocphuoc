using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web_BookManager.Models;
namespace Web_BookManager.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult ListBook()
        {

            BookManagerContext con = new BookManagerContext();
            var ListBook = con.Books.ToList();
            return View(ListBook);
        }

        [Authorize]
        public ActionResult Buy(int id)
        {
            BookManagerContext con = new BookManagerContext();
            Book book = con.Books.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        public ActionResult Create()
        {
            return View();
        }
        [Authorize]
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID, Title, Description, Author, Images, Price")] Book book)
        {
            BookManagerContext con = new BookManagerContext();
            List<Book> listBook = con.Books.ToList();
            if (ModelState.IsValid)
            {
                con.Books.AddOrUpdate(book);
                con.SaveChanges();

            }
            return RedirectToAction("ListBook", listBook);
        }
        public ActionResult Edit(int? id)
        {
            BookManagerContext con = new BookManagerContext();
            List<Book> listBook = con.Books.ToList();
            Book book = con.Books.Find(id);
            if (id == null)
            {
                return HttpNotFound();
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View();
        }
        [Authorize]
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, Title, Description,Author, Images, Price")] Book book)
        {
            BookManagerContext con = new BookManagerContext();
            List<Book> listBook = con.Books.ToList();
            if (ModelState.IsValid)
            {
                con.Books.AddOrUpdate(book);
                con.SaveChanges();

            }
            return RedirectToAction("ListBook", listBook);
        }
       



        public ActionResult Delete(int? id)
        {
            BookManagerContext con = new BookManagerContext();
            List<Book> listBook = con.Books.ToList();
            Book book = con.Books.Find(id);

            if (id == null)
            {
                return new HttpStatusCodeResult(BookManagerContext.BadRequest);
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            BookManagerContext con = new BookManagerContext();
            List<Book> listBook = con.Books.ToList();
            Book book = con.Books.Find(id);
            con.Books.Remove(book);
            con.SaveChanges();
            return RedirectToAction("ListBook", listBook);
        }
    }
}