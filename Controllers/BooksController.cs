using KutuphaneUygulamasi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering; 
using Microsoft.EntityFrameworkCore; 
using System.Linq;

namespace KutuphaneUygulamasi.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Kitapları çekerken ilişkili olduğu Category bilgisini de dahil ediyoruz
            var books = _context.Books.Include(b => b.Category).ToList();
            return View(books);
        }

        [HttpGet]
        public IActionResult Add()
        {
            // Kategorileri veritabanından çekip dropdown için View'e gönderiyoruz
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Book newBook)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(newBook);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Kitap başarıyla eklendi.";
                return RedirectToAction("Index");
            }

            // Veri hatalıysa form dönerken dropdown listesinin boş gelmemesi için listeyi tekrar dolduruyoruz
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
            return View(newBook);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name", book.CategoryId);
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Book updatedBook)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Update(updatedBook);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Kitap bilgileri başarıyla güncellendi.";
                return RedirectToAction("Index");
            }

            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name", updatedBook.CategoryId);
            return View(updatedBook);
        }

        public IActionResult Remove(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Kitap başarıyla silindi.";
            }
            return RedirectToAction("Index");
        }
    }
}