using ebookSwapApllication.Data;
using ebookSwapApllication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ebookSwapApllication.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;

        public BooksController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {

            if (HttpContext.Session.GetInt32("sessionKeyUserId") == 0 || string.IsNullOrEmpty(HttpContext.Session.GetString("sessionKeyUsername")))
            {
                ViewBag.checkiflogin = "false";


            }
            else
            {
                ViewBag.checkiflogin = "true";

            }


            var allbooks = await _context.Books.Include(n => n.User).ToListAsync();

                return View(allbooks);
            


        }

        [HttpGet]
        public async Task<IActionResult> Index(string booksearch)
        {
            //if (HttpContext.Session.GetInt32("sessionKeyUserId") == 0 || HttpContext.Session.GetInt32("sessionKeyUserId") == null)
            //{
            //    return RedirectToAction("Login", "Users");
            //}else
            //{

            

            ViewData["getbookdetail"] = booksearch;

                var bookquery = from x in _context.Books.Include(n => n.User) select x;

                if (!string.IsNullOrEmpty(booksearch))
            {
                bookquery = bookquery.Where(x => x.BookTitle.Contains(booksearch) || x.BookISBN13.Contains(booksearch) || x.BookAuthor.Contains(booksearch) || x.BookCategory.Contains(booksearch) || x.BookLanguage.Contains(booksearch)|| x.User.UserCity.Contains(booksearch));
            }

            return View(await bookquery.AsNoTracking().ToListAsync());
            //}

        }



        public async Task<IActionResult> Details(int? id)
        {
            //if (HttpContext.Session.GetInt32("sessionKeyUserId") == 0 || HttpContext.Session.GetInt32("sessionKeyUserId") == null)
            //{
            //    return RedirectToAction("Login", "Users");
            //}
            //else
            //{

            if (HttpContext.Session.GetInt32("sessionKeyUserId") == 0 || string.IsNullOrEmpty(HttpContext.Session.GetString("sessionKeyUsername")))
            {
                ViewBag.checkiflogin = "false";


            }
            else
            {
                ViewBag.checkiflogin = "true";

            }

            if (id == null || _context.Books == null)
                {
                    return NotFound();
                }

                var book = await _context.Books.Include(n => n.User)
                     .FirstOrDefaultAsync(m => m.BookId == id);

                ViewBag.countbookbookdetail = _context.Books.Where(x=>x.UserId == book.UserId).Count();


                if (book == null)
                {
                    return NotFound();
                }

                return View(book);
            //}
        }
    
        // GET: Books/Create
        public IActionResult Create()
        {
            //Book book = new Book();
            //book.BookCategoryList = new SelectList(_context.Books.ToList(), "BookCategory", "BookCategory");

            if (HttpContext.Session.GetInt32("sessionKeyUserId") == 0 || string.IsNullOrEmpty(HttpContext.Session.GetString("sessionKeyUsername")))
            {
                return RedirectToAction("Login", "Users");
            }
            else
            {
                var categories = _context.Books.Select(b => b.BookCategory).Distinct().ToList();

                // Store categories in ViewBag
                ViewBag.Categories = categories;




                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookTitle", "BookLanguage", "BookAuthor", "BookCondition", "UserId", "BookNotes", "BookCategory", "BookISBN13", "BookNumPages", "BookPublicationDate", "BookPublisherID", "BookDescription", "BookFilePath")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            // If the model state is not valid, retrieve the categories again and pass them to the view
            var categories = _context.Books.Select(b => b.BookCategory).Distinct().ToList();
            ViewBag.Categories = categories;

            return View(book);
        }


        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
            // return RedirectToAction("Index", "Books");

        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Books == null)
            {
                return Problem("Entity set 'AppDbContext.Books'  is null.");
            }
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

           // return RedirectToAction("Index", "Books");

        }
    }
}
