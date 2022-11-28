using ebookSwapApllication.Data;
using ebookSwapApllication.Models;
using Microsoft.AspNetCore.Mvc;
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

            var allbooks = await _context.Books.Include(n=>n.User).ToListAsync();
            return View(allbooks);

        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books.Include(n => n.User)
                 .FirstOrDefaultAsync(m => m.BookId == id);


            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }
    
        // GET: Books/Create
        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("UserId,UserName,UserFullName,UserEmail,UserPassword,Userphonenumber,UserCity,UserCountry,UserAdress,UserDateCreating")] Book book)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(book);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(book);
        //}
    }
}
