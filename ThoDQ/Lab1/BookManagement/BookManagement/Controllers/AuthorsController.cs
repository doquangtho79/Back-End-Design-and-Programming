using BookManagement.Data;
using BookManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookManagement.Controllers
{
    public class AuthorsController : Controller
    {
        public IActionResult Index() => View(AuthorRepository.GetAll());

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                AuthorRepository.Add(author);
                return RedirectToAction("Index");
            }
            return View(author);
        }
    }

}
