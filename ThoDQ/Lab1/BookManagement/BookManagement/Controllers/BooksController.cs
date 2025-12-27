using System.Linq;
using BookManagement.Data;
using BookManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookManagement.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Index() => View(BookRepository.GetAll());

        public IActionResult Create()
        {
            // Show only author Name in the listbox
            ViewBag.Authors = new SelectList(AuthorRepository.GetAll(), "Name", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                BookRepository.Add(book);
                return RedirectToAction("Index");
            }

            ViewBag.Authors = new SelectList(AuthorRepository.GetAll(), "Name", "Name", book.Author);
            return View(book);
        }

        // GET: Books/Edit/5
        public IActionResult Edit(int id)
        {
            var book = BookRepository.GetById(id);
            if (book == null) return NotFound();

            ViewBag.Authors = new SelectList(AuthorRepository.GetAll(), "Name", "Name", book.Author);
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Book book)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Authors = new SelectList(AuthorRepository.GetAll(), "Name", "Name", book.Author);
                return View(book);
            }

            var updated = BookRepository.Update(book);
            if (!updated) return NotFound();

            return RedirectToAction("Index");
        }
    }
}

