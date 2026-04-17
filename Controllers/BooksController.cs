using KutuphaneUygulamasi.Models;
using Microsoft.AspNetCore.Mvc;
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
            var books = _context.Books.ToList();
            return View(books);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Form güvenliği için eklendi
        public IActionResult Add(Book newBook)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(newBook);
                _context.SaveChanges();

                // Başarılı işlem mesajı eklendi
                TempData["SuccessMessage"] = "Kitap başarıyla eklendi.";
                return RedirectToAction("Index");
            }

            // Veri hatalıysa aynı view'ı model ile geri döndür
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
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Form güvenliği için eklendi
        public IActionResult Update(Book updatedBook)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Update(updatedBook);
                _context.SaveChanges();

                // Başarılı işlem mesajı eklendi
                TempData["SuccessMessage"] = "Kitap bilgileri başarıyla güncellendi.";
                return RedirectToAction("Index");
            }

            // Veri hatalıysa aynı view'ı model ile geri döndür
            return View(updatedBook);
        }

        public IActionResult Remove(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();

                // Başarılı işlem mesajı eklendi
                TempData["SuccessMessage"] = "Kitap başarıyla silindi.";
            }
            return RedirectToAction("Index");
        }
    }
}