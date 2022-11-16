using ebookSwapApllication.Data;
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
    }
}
